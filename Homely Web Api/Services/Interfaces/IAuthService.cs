using Homely_Web_Api.DTOs.UserDTOs;

namespace Homely_Web_Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task<AuthResponseDto> RefreshTokenAsync(RefreshTokenReqDto token);
        Task<bool> LogoutAsync(LogoutReqDto token);

        Task<bool> AssignRoleAsync(AssignRoleDto req);
    }
}
