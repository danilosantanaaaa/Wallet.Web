using System.ComponentModel.DataAnnotations;

using Wallet.Web.Common.Models;

namespace Wallet.Web.Models;

public class Contato : BaseModel
{
    [Required]
    public string Nome { get; set; } = default!;

    [EmailAddress]
    public string Email { get; set; } = default!;

    [Phone]
    public string Telefone { get; set; } = default!;
}