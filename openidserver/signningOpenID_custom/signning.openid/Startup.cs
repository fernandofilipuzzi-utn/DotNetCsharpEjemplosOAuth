using IdentityModel.Client;
using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;

[assembly: OwinStartup(typeof(signning.openid.Startup))]
namespace signning.openid
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", idsrvApp =>
            {
                var factory = new IdentityServerServiceFactory()
                                                   .UseInMemoryUsers(Users.Get())
                                                   .UseInMemoryClients(Clients.Get())
                                                   .UseInMemoryScopes(Scopes.Get());

                factory.ViewService = new Registration<IViewService, CustomViewService>();

                idsrvApp.UseIdentityServer(new IdentityServerOptions
                {

                    Factory =factory,


                    RequireSsl = true, // Cambiar a true en producción
                    SigningCertificate = LoadCertificate(),
                    AuthenticationOptions = new IdentityServer3.Core.Configuration.AuthenticationOptions
                    {
                        EnablePostSignOutAutoRedirect = true,
                        EnableSignOutPrompt = false,
                        IdentityProviders = ConfigureIdentityProviders
                    }

                });
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                Authority = "https://localhost:44394/identity",

                ClientId = "mvc",
                Scope = "openid profile roles sampleApi",
                ResponseType = "id_token token",
                RedirectUri = "https://localhost:44394/",

                SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                UseTokenLifetime = false,
            });

        }

        private X509Certificate2 LoadCertificate()
        {
            string pfxPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certs", "certificate.pfx");
            string pfxPassword = "password";

            if (!File.Exists(pfxPath))
            {
                throw new FileNotFoundException("El archivo de certificado no se encontró.", pfxPath);
            }

            return new X509Certificate2(pfxPath, pfxPassword);
        }

        private void ConfigureIdentityProviders(IAppBuilder app, string signInAsType)
        {
            string ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            string ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                AuthenticationType = "Google",
                Caption = "Sign-in with Google",
                SignInAsAuthenticationType = signInAsType,
                CallbackPath = new PathString("/"),
                ClientId = ClientId,
                ClientSecret = ClientSecret
            });
        }
    }

    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "user",
                    Password = "password",
                    Subject = "1"
                }
            };
        }
    }

    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "Client Application",
                    ClientId = "tu_client_id",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44368/Default.aspx" // URL de redirección después de login
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44368/Default.aspx" // URL de redirección después de cerrar sesión
                    },
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                         Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email
                    }
                }
            };
        }
    }

    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email
            };
        }
    }
}