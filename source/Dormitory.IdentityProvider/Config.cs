using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4;

namespace Dormitory.IdentityProvider
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    Username = "Frank",
                    Password = "Password",
                    SubjectId = "123",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Franks")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "dormitoriesclient",
                    ClientName = "Dormitory Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:4200/signin-oidc"
                    },
                    AccessTokenLifetime = 180,
                    PostLogoutRedirectUris = new[]
                    {
                        "https://localhost:4200"
                    },
                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         "dormitoryapi"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "https://127.0.0.1:4200",
                        "https://localhost:4200"
                    }
                },
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets =  {new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44356/signin-oidc" },

                    AllowedScopes = new[]
                    {
                        "ApiOne", IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile
                    },
                    RequireConsent = false
                }
            };
        }
    }
}
