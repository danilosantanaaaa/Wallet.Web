using System.ComponentModel.DataAnnotations;

namespace Wallet.Web.Models.Users;

public class RegisterModel
{
    [MinLength(8)]
    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}