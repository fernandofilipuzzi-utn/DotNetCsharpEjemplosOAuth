using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

[assembly: OwinStartup(typeof(signning.openid.Startup))]
namespace signning.openid
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get()),

                RequireSsl = true, // Cambiar a true en producción
                SigningCertificate = LoadCertificate(),

                AuthenticationOptions = new AuthenticationOptions
                {
                    EnablePostSignOutAutoRedirect = true,
                    EnableSignOutPrompt = false
                }
            };

            app.UseIdentityServer(options);
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
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44368/Default.aspx" // URL de redirección después de login
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44368/Logout.aspx" // URL de redirección después de cerrar sesión
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