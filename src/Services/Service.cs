using System.Net.Http.Json;

using FriendlyResult;

using Wallet.Web.Common;
using Wallet.Web.Common.Models;

namespace Wallet.Web.Services;

public abstract class Service(IHttpClientFactory clientFactory)
{
    protected readonly HttpClient _client = clientFactory.CreateClient(Config.ApiName);
    protected abstract string BaseUrl { get; }

    public async Task<Result<IEnumerable<TModel>>> GetAllAsync<TModel>(string? baseUrl = null)
    {
        try
        {
            var response = await _client.GetAsync(baseUrl ?? BaseUrl);
            var result = await HandlingReturnResponse<IEnumerable<TModel>>(response);

            if(result.IsError)
            {
                return result.Errors;
            }

            return result.Value.ToList();
        }
        catch (Exception ex)
        {
            return Error.Validation(code: "Problema:", description: ex.Message);
        }
    }

    public async Task<Result<TModel?>> GetByIdAsync<TModel>(Guid id, string? baseUrl = null)
    {
        try
        {
            var response = await _client.GetAsync($"{baseUrl ?? BaseUrl}/{id}");
            return await HandlingReturnResponse<TModel?>(response);
        }
        catch (Exception ex)
        {
            return Error.Validation(code: "Problema:", description: ex.Message);
        }
    }

    public async Task<Result<Guid>> CreateAsync<TModel>(TModel content, string? baseUrl = null)
    {
        try
        {
            var response = await _client.PostAsJsonAsync(baseUrl ?? BaseUrl, content);
            return await HandlingReturnResponse<Guid>(response);
        }
        catch (Exception ex)
        {
            return Error.Validation(code: "Problema:", description: ex.Message);
        }
    }

    public async Task<Result<Guid>> UpdateAsync<TModel>(Guid id, TModel content, string? baseUrl = null)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"{baseUrl ?? BaseUrl}/{id}", content);

            if (!await HasContent(response))
            {
                return id;
            }

            var result = await HandlingReturnResponse<Guid>(response);
            if (result.IsError)
            {
                return result.Errors;
            }

            return result.Value;

        }
        catch (Exception ex)
        {
            return Error.Validation(code: "Problema:", description: ex.Message);
        }
    }

    protected async Task<Result<TModel>> HandlingReturnResponse<TModel>(HttpResponseMessage response)
    {
        try
        {
            if (!response.IsSuccessStatusCode)
            {
                var problemDeatils = await response.GetContentAsync<ClientProblemDetails?>();

                return Error.Validation(
                    problemDeatils?.Status.ToString() ?? "Error.Generico",
                    problemDeatils?.Detail ?? "Erro generico.");
            }
        }
        catch
        {
            return Error.Validation(response.StatusCode.ToString(), "");
        }

        return (await response.GetContentAsync<TModel>())!;
    }

    protected async Task<bool> HasContent(HttpResponseMessage response) =>
        await response.Content.ReadAsStringAsync() != string.Empty;
}
