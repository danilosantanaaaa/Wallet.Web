using System.Net;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;

using Wallet.Web.Models.Users;

namespace Wallet.Web.Common.Interceptors;

public class JwtAuthenticationHandler(
    NavigationManager navigationManager,
    ILocalStorageService storageService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var authentication = await storageService.GetItemAsync(
            AuthenticationResultModel.Key
        );

        if (authentication is not null)
        {
            request.Headers.Add("Authorization", $"Bearer {authentication.Token}");
        }

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            navigationManager.NavigateTo("/", forceLoad: true);
        }

        return response;
    }
}