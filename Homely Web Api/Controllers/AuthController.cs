using Azure.Core;
using Homely_Web_Api.DTOs.UserDTOs;
using Homely_Web_Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homely_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            try
            {
                var result = await _authService.RegisterAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            try
            {
                var result = await _authService.LoginAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenReqDto token)
        {
            try
            {
                var result = await _authService.RefreshTokenAsync(token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutReqDto token)
        {
            try
            {
                var result = await _authService.LogoutAsync(token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("assign-role")]
        [Authorize]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto req)
        {
            try
            {
                var result = await _authService.AssignRoleAsync(req);

                if (!result) return BadRequest(new { message = "Role already assigned" });

                return Ok(new { message = "Role assigned successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }



        }
    }
}
