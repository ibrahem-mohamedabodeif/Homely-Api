using Homely_Web_Api.Data;
using Homely_Web_Api.DTOs.UserDTOs;
using Homely_Web_Api.Models;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Homely_Web_Api.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AuthService(ITokenService tokenService, IConfiguration configuration,AppDbContext context)
        {
            _tokenService = tokenService;
            _configuration = configuration;
            _context = context;
        }
        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {
            if (await _context.AppUsers.AnyAsync(u => u.Email == registerDto.Email))
            {
                throw new Exception("User already registered");
            }
            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
            };
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            var guestRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "guest");
            if (guestRole == null)
            {
                throw new Exception("Guest role not found");
            }

            await _context.AppUserRoles.AddAsync(new AppUserRole
            {
                AppUserId = user.Id,
                RoleId = guestRole.Id
            });

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.AppUsers
                .Include(u => u.AppUserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            var token = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token,
                RefreshToken = refreshToken.Token,
                TokenExpires = refreshToken.ExpiresAt,
                Roles = user.AppUserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }


        public async Task<bool> LogoutAsync(LogoutReqDto token)
        {
            var refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(rt => rt.Token == token.RefreshToken);

            if (refreshToken == null || refreshToken.IsRevoked || refreshToken.IsExpired)
                return false;

            refreshToken.RevokedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenReqDto token)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(token.Token);
            if (principal == null)
            {
                throw new SecurityTokenException("Invalid token");
            }

            var userId = int.Parse(principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value ?? throw new SecurityTokenException("Invalid token"));
            var user = await _context.AppUsers.Include(u => u.AppUserRoles)
                                              .ThenInclude(ur => ur.Role)
                                              .Include(u => u.RefreshTokens)
                                              .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var refreshToken = user.RefreshTokens.FirstOrDefault(rt => rt.Token == token.RefreshToken);
            if (refreshToken == null || !refreshToken.IsActive)
            {
                throw new SecurityTokenException("Invalid refresh token");
            }
            refreshToken.RevokedAt = DateTime.UtcNow;

            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                TokenExpires = newRefreshToken.ExpiresAt,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.AppUserRoles.Select(r => r.Role.Name).ToList()
            };
        }

        public async Task<bool> AssignRoleAsync(AssignRoleDto req)
        {
            var user = await _context.AppUsers
                .Include(u => u.AppUserRoles)
                .FirstOrDefaultAsync(u => u.Id == req.UserId); 

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == req.RoleName.ToLower());
            if (role == null)
            {
                throw new Exception("Role not found");
            }

            if (user.AppUserRoles.Any(ur => ur.RoleId == role.Id))
            {
                throw new Exception("User already has this role");
            }

            user.AppUserRoles.Add(new AppUserRole
            {
                AppUserId = user.Id,
                RoleId = role.Id
            });

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
