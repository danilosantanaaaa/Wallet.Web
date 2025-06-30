using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;

using Wallet.Web.Models.Users;

public class WalletAuthenticationProvider(ILocalStorageService storage) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwt = await storage.GetItemAsync<AuthenticationResultModel>(AuthenticationResultModel.Key);

        if (jwt is null)
        {
            return new(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        return new(CreateClaimsPrincipalFromToken(jwt!));
    }

    public void MarkUserAsAuthenticated()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private static ClaimsPrincipal CreateClaimsPrincipalFromToken(AuthenticationResultModel token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var identity = new ClaimsIdentity();

        if (tokenHandler.CanReadToken(token.Token))
        {
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token.Token);
            identity = new(jwtSecurityToken.Claims, "Bearer");

            identity.AddClaim(new Claim(ClaimTypes.Role, identity.FindFirst("id")!.Value));
        }

        return new(identity);
    }
}