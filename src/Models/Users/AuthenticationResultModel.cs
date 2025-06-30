using Wallet.Web.Common.Models;

namespace Wallet.Web.Models.Users;

public record AuthenticationResultModel(
    string Nome,
    string Email,
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpiry)
{
    public static string Key => "JwtToken";
}