using System.ComponentModel.DataAnnotations;

namespace Wallet.Web.Models.Users;

public class LoginModel
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}