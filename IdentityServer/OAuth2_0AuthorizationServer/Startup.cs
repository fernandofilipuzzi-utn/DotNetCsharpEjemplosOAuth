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
using OAuth2_0AuthorizationServer.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using OAuth2_0AuthorizationServer.Configuration;

[assembly: OwinStartup(typeof(OAuth2_0AuthorizationServer.Startup))]
namespace OAuth2_0AuthorizationServer
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
                    RequireSsl = false
                });

            });
            
            /*
            #region restringir al identityserver
            app.Use(async (context, next) =>
            {
                // verificando credenciales
                if (UsuarioNoAutenticado(context))
                {
                    context.Response.StatusCode = 401; // No autorizado
                    return;
                }

                #region  identidad de usuario
                //string nombreUsuario = "usuario1";
                //IEnumerable<Claim> claims = ObtenerClaimsUsuario(); 
                //EstablecerIdentidadUsuario(HttpContext.Current.GetOwinContext(), nombreUsuario, claims);
                #endregion

                await next.Invoke();
            });
            #endregion
            */
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }

        #region restringir al identityserver
        private bool UsuarioNoAutenticado(IOwinContext context)
        {
            // Implementa la lógica para verificar si el usuario está autenticado
            // se puede usar el contexto para acceder a la información del usuario, por ejemplo, context.Authentication.User
            return !context.Authentication.User.Identity.IsAuthenticated;
        }

        private void EstablecerIdentidadUsuario(IOwinContext context, string nombreUsuario, IEnumerable<Claim> claims)
        {
            
            // utilizar el contexto para acceder a la información del usuario y establecer la identidad
            // Ejemplo: context.Authentication.User = nuevaIdentidad;

            // creando la identidad para el usuario
            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            // identidad del usuario en el contexto
            context.Authentication.SignIn(identity);
        }

        private IEnumerable<Claim> ObtenerClaimsUsuario()
        {
            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;

            // verifica si la identidad es ClaimsIdentity y no es nula
            if (identity != null)
            {
                return identity.Claims;
            }
            return new List<Claim>();
        }
        #endregion
    }
}