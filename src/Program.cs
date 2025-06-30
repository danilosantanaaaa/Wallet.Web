using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor.Services;

using Wallet.Web;
using Wallet.Web.Common;
using Wallet.Web.Common.Interceptors;
using Wallet.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiUrl"] ??
    throw new NullReferenceException();

builder.Services.AddHttpClient(Config.ApiName, client =>
{
    client.BaseAddress = new Uri(apiUrl);
}).AddHttpMessageHandler<JwtAuthenticationHandler>();

builder.Services.AddTransient<JwtAuthenticationHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredLocalStorageAsSingleton();

builder.Services.AddMudServices();

// Adicionando serviços
builder.Services.AddScoped<CarteiraService>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<CobrancaService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddSingleton<WalletAuthenticationProvider>();
builder.Services.AddSingleton<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<WalletAuthenticationProvider>());

await builder.Build().RunAsync();
