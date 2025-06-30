
namespace Wallet.Web.Services;

public class CategoriaService(IHttpClientFactory clientFactory) : Service(clientFactory)
{
    protected override string BaseUrl => "api/v1/categorias";
}
