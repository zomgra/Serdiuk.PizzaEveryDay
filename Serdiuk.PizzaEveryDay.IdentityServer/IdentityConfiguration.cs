using IdentityServer4.Models;
using IdentityServer4;

public static class IdentityConfiguration
{
    internal static IEnumerable<ApiResource> ApiResources()
    {
        yield return new ApiResource("PizzaApi", "Pizza every day");
    }

    internal static IEnumerable<ApiScope> ApiScopes()
    {
        yield return new ApiScope("PizzaApi", "Pizza every day");
    }

    internal static IEnumerable<Client> Clients()
    {
        yield return new Client()
        {
            RedirectUris = { "http://localhost:3000/signin-oidc" },
            AllowedGrantTypes = GrantTypes.Implicit,
            ClientId = "pizza-api",
            ClientName = "PizzaApi",
            RequireClientSecret = false,
            RequirePkce = true,
            AllowedScopes =
            {
                "PizzaApi",
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
            },
            AllowedCorsOrigins =
            {
                "http://localhost:3000"
            },
            PostLogoutRedirectUris =
            {
                "http://localhost:3000/signout-oidc"
            },
            AllowAccessTokensViaBrowser = true,
            AllowOfflineAccess = true,
        };
    }

    internal static IEnumerable<IdentityResource> IdentityResources()
    {
        yield return new IdentityResources.OpenId();
        yield return new IdentityResources.Profile();
        yield return new IdentityResources.Email();

    }
}