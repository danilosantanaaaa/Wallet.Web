using System.Text.Json.Serialization;

namespace Wallet.Web.Models.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CategoriaTipo
{
    Entrada,
    Saida
}