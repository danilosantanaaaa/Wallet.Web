using System.ComponentModel.DataAnnotations;

using Wallet.Web.Common.Models;
using Wallet.Web.Models.Enums;

namespace Wallet.Web.Models;

public class Categoria : BaseModel
{
    [Required]
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;
    public CategoriaTipo Tipo { get; set; }
}