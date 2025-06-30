
using FriendlyResult;

using Wallet.Web.Models.Reports;

namespace Wallet.Web.Services;

public class CobrancaService(IHttpClientFactory clientFactory) : Service(clientFactory)
{
    protected override string BaseUrl => "api/v1/cobrancas";

    public async Task<Result<CobrancaReport>> GetReportAsync()
    {
        try
        {
            var response = await _client.GetAsync($"{BaseUrl}/report");

            return await HandlingReturnResponse<CobrancaReport>(response);
        }
        catch (Exception ex) {
            return Error.Validation(code: "Problema:", description: ex.Message);
        }
    }
}