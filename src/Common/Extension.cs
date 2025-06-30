using System.Net.Http.Json;

namespace Wallet.Web.Common;

public static class Extension
{
    public static async Task<TModel?> GetContentAsync<TModel>(this HttpResponseMessage response)
    {
        return await response.Content.ReadFromJsonAsync<TModel?>();
    }

    public static bool IsNew(this Guid id)
    {
        return id == Guid.Empty;
    }

    public static string TruncateAsEllipsis(this Guid id, int amount = 8)
    {
        return $"{id.ToString()[..amount]}...";
    }
}