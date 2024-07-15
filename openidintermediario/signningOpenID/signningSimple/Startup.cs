using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(signningSimple.Startup))]
namespace signningSimple
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuración de autenticación de cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ////// ExpireTimeSpan = TimeSpan.FromMinutes(3),
                // AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                // LoginPath = new PathString("/login"),
                // LogoutPath = new PathString("/logout"),
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login.aspx")
            });

            // Configuración de autenticación de Google
            string clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                CallbackPath = new PathString("/Authorize"),
                // SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
               // SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie

            });
        }
    }
}