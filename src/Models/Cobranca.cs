using System.ComponentModel.DataAnnotations;

using Wallet.Web.Common.Models;
using Wallet.Web.Models.Enums;

namespace Wallet.Web.Models;

public class Cobranca : BaseModel
{
    [Required]
    public string Descricao { get; set; } = default!;

    [Required]
    public decimal Valor { get; set; }
    public CobrancaStatus Status { get; set; }
    public Guid CarteiraId { get; set; } = Guid.Empty;
    public Guid CategoriaId { get; set; } = Guid.Empty;
    public Guid ContatoId { get; set; } = Guid.Empty;
}