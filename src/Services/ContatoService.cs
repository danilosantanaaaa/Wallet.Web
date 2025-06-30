
namespace Wallet.Web.Services;

public class ContatoService(IHttpClientFactory clientFactory) : Service(clientFactory)
{
    protected override string BaseUrl => "api/v1/contatos";
}
