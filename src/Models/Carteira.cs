using System.ComponentModel.DataAnnotations;

using Wallet.Web.Common.Models;

namespace Wallet.Web.Models;

public class Carteira : BaseModel
{
    [Required]
    public string Nome { get; set; } = default!;

    public string Descricao { get; set; } = default!;
}