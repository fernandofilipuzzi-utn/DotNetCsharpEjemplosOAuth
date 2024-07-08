using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

[assembly: OwinStartup(typeof(signning.client.Startup))]
namespace signning.client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configurar autenticación basada en cookies
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ExpireTimeSpan = TimeSpan.FromMinutes(3),
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new PathString("/Default"),
                LogoutPath = new PathString("/Default")
            });

            // Configurar OpenID Connect para autenticación
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "tu_client_id",
                Authority = "https://localhost:44394/identity",
                RedirectUri = "https://localhost:44368/Default.aspx", // URL de redirección después de login
                PostLogoutRedirectUri= "https://localhost:44368/Default.aspx",
                ResponseType = "id_token token",
                Scope = "openid email", // Scopes solicitados
                SignInAsAuthenticationType = CookieAuthenticationDefaults.AuthenticationType,


                //Notifications = new OpenIdConnectAuthenticationNotifications
                //{
                //    AuthorizationCodeReceived = async n =>
                //    {
                //        var idToken = n.ProtocolMessage.IdToken;
                //        var accessToken = n.ProtocolMessage.AccessToken;
                //        HttpContext.Current.Response.Redirect("/"); // Redirigir a la página principal
                //    },

                //    AuthenticationFailed = n =>
                //    {
                //        HttpContext.Current.Response.Redirect("/Error?message=" + n.Exception.Message);
                //        return Task.FromResult(0);
                //    }
                //}
            });
        }
    }
}