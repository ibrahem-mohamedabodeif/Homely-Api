using Homely_Web_Api.Models;
using System.Security.Claims;

namespace Homely_Web_Api.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(AppUser user);
        RefreshToken GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
