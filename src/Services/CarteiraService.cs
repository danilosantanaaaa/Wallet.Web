
namespace Wallet.Web.Services;

public class CarteiraService(IHttpClientFactory clientFactory) : Service(clientFactory)
{
    protected override string BaseUrl => "api/v1/carteiras";
}