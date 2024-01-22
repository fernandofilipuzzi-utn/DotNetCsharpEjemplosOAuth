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

[assembly: OwinStartup(typeof(OAuth2._0Service.Startup))]
//[assembly: OwinStartupAttribute(typeof(OAuth2._0Service.Startup))]
namespace OAuth2._0Service
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*
            var factory = new IdentityServerServiceFactory()
               .UseInMemoryClients(Clients.Get())
               .UseInMemoryScopes(Scopes.Get())
               .UseInMemoryUsers(Users.Get());

            var options = new IdentityServerOptions
            {
                SiteName = "Demo Identity Server",
                SigningCertificate = Cert.Load(),
                Factory = factory,
                RequireSsl = false
            };

          

            app.UseIdentityServer(options);
         */
            //app.UseCors(CorsOptions.AllowAll);


            var factory = new IdentityServerServiceFactory()
                       .UseInMemoryClients(Clients.Get())
                       .UseInMemoryScopes(Scopes.Get())
                       .UseInMemoryUsers(Users.Get());
                       

            //.AddDeveloperSigningCredential(); 
            

            app.Map("/identity", id => {
                id.UseIdentityServer(new IdentityServerOptions
                {
                    
                    AuthenticationOptions = new AuthenticationOptions {
                        
                    },
                    
                    SiteName = "Demo Identity Server",
                    SigningCertificate = Cert.Load(),
                    Factory = factory,
                    RequireSsl = false
                });

            });
        

        }
        /*
        public void ConfigureOAuth(IAppBuilder app)
        {
            Console.WriteLine("owin");
            app.CreatePerOwinContext<OwinAuthDbContext>(() => new OwinAuthDbContext());
            app.CreatePerOwinContext<UserManager<IdentityUser>>(CreateManager);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var provider = new MyAuthorizationServerProvider();
            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = false, //have also tried with true here
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = provider
            };
            app.UseOAuthAuthorizationServer(option);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

        private static UserManager<IdentityUser> CreateManager(IdentityFactoryOptions<UserManager<IdentityUser>> options, IOwinContext context)
        {
            var userStore = new UserStore<IdentityUser>(context.Get<OwinAuthDbContext>());
            var owinManager = new UserManager<IdentityUser>(userStore);
            return owinManager;
        }
        */
    }
}