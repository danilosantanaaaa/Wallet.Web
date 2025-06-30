using System.Net.Http.Json;

using Blazored.LocalStorage;

using FriendlyResult;

using Microsoft.AspNetCore.Components;

using Wallet.Web.Models.Users;

namespace Wallet.Web.Services;

public class UserService(
    IHttpClientFactory clientFactory,
    ILocalStorageService localStorage,
    WalletAuthenticationProvider authenticationProvider) : Service(clientFactory)
{
    protected override string BaseUrl => "./api/v1/users";

    public async Task<Result<AuthenticationResultModel>> LoginAsync(LoginModel model)
    {
        try
        {
            var response = await _client.PostAsJsonAsync($"{BaseUrl}/login", model);

            var result = await HandlingReturnResponse<AuthenticationResultModel>(response);
            if (result.IsError)
            {
                return result.Errors;
            }

            await localStorage.SetItemAsync(
                AuthenticationResultModel.Key,
                result.Value);

            authenticationProvider.MarkUserAsAuthenticated();

            return result.Value;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Result<AuthenticationResultModel>> RegisterAsync(RegisterModel model)
    {
        try
        {
            var response = await _client.PostAsJsonAsync($"{BaseUrl}/register", model);

            var result = await HandlingReturnResponse<AuthenticationResultModel>(response);
            if (result.IsError)
            {
                return result.Errors;
            }

            await localStorage.SetItemAsync(
                AuthenticationResultModel.Key,
                result.Value);

            authenticationProvider.MarkUserAsAuthenticated();

            return result.Value;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task RevokeAsync()
    {
        await localStorage.RemoveItemAsync(AuthenticationResultModel.Key);
    }
}
