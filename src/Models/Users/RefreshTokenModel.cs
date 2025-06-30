using System.ComponentModel.DataAnnotations;

namespace Wallet.Web.Models.Users;

public class RefreshTokenModel
{
    [Required]
    public string Token { get; set; } = default!;

    [Required]
    public string RefreshToken { get; set; } = default!;
}