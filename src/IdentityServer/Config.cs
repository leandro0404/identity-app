using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerWithMvc
{
    public class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client
            return new List<Client>
            {
                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false,

                    RedirectUris = { "http://localhost:5001/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        "website"
                    }
                },

                  // OpenID Connect implicit flow client (MVC
                new Client {
                    ClientId = "angularoidc",
                    ClientName = "Angular OpenId Connect",
                    //AccessTokenLifetime = 600, // 10 minutes, default 60 minutes
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:4200/login-callback" },
                    PostLogoutRedirectUris =  { "http://localhost:4200/login-callback" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                    }
                },
               new Client  {
                    ClientId ="reactoidc",
                    ClientName = "react OpenId Connect",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:3000/callback.html" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:3000/index.html" },

                    AllowedCorsOrigins = { "http://localhost:3000" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                    }

                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "leandro",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "leandro"),
                        new Claim(JwtClaimTypes.GivenName, "leandro silveira"),
                        new Claim(JwtClaimTypes.FamilyName, "silveira"),
                        new Claim(JwtClaimTypes.Email, "leandrobhmgg@gmail.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://leandrosilveira.dev/"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Rua Firmino duarte', 'locality': 'Minas gerais', 'postal_code': 30500400, 'country': 'Brazil' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)

                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "jp",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "JP"),
                        new Claim(JwtClaimTypes.GivenName, "Joao Pedro"),
                        new Claim(JwtClaimTypes.FamilyName, "Silva"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://globo.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'Rua Um', 'locality': 'Sao Paulo', 'postal_code': 3330500, 'country': 'Brasil' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "Brazil")
                    }
                }
            };
        }
    }
}