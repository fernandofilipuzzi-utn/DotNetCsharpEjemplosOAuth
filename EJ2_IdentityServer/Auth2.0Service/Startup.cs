using Auth2._0Service.Models;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(Auth2._0Service.Startup))]
//[assembly: OwinStartupAttribute(typeof(Auth2._0Service.Startup))]
namespace Auth2._0Service
{
    

    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            
            var factory = new IdentityServerServiceFactory()
               .UseInMemoryClients(Clients.Get())
               .UseInMemoryScopes(Scopes.Get())
               .UseInMemoryUsers(Users.Get());
                //.AddDeveloperSigningCredential(); 
            /*
            var options = new IdentityServerOptions
            {
                Factory = factory,
               // SigningCertificate = Cert.Load(),
                RequireSsl = false
            };

            app.UseIdentityServer(options);
            */

            //string connectionString = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            app.Map("/identity", id => {
                id.UseIdentityServer(new IdentityServerOptions
                {
                    SiteName = "Demo Identity Server",
                    // SigningCertificate = LoadCertificate()
                    SigningCertificate = Cert.Load(),
                    Factory = factory //new IdentityServerServiceFactory().Configure(connectionString),
                });

            });
        }

    }
}