using OAuth2._0Service.Models;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using IdentityServer3.Core.Services;

[assembly: OwinStartup(typeof(OAuth2._0Service.Startup))]
namespace OAuth2._0Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/identity", identity => {

                var factory = new IdentityServerServiceFactory()
                       .UseInMemoryClients(Clients.Get())
                       .UseInMemoryScopes(Scopes.Get())
                       .UseInMemoryUsers(Users.Get());

                identity.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Demo Identity Server",
                    SigningCertificate = Cert.Load(),
                    Factory = factory,
                    RequireSsl = false,
                });

            });
            // app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}