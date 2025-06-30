using Wallet.Web.Models.Enums;

namespace Wallet.Web.Models.Reports;

public record CobrancaReport(
    CobrancaByTipo[] CobrancaByTipo,
    List<CobrancaGroup> CobrancaGroups);

public record CobrancaByTipo(
    CategoriaTipo Tipo,
    decimal Total);

public record CobrancaGroup(
    string CategoriaName,
    CategoriaTipo Tipo,
    decimal Valor_Total);