using ResourceAPIServer;
using ResourceAPIServer.Models;
using IdentityServer3.AccessTokenValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Security.Claims;
using ResourceAPIServer.Utils;

[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
             
        }
                
        private void ConfigureOAuth(IAppBuilder app)
        {
            var issuer = "http://localhost:7777/identity";
            var audience = "http://localhost:7777/identity/resources";

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeyResolver = (token, securityToken, identifier, parameters) =>
                    {
                        var cert = Cert.Load();
                        var key = new X509SecurityKey(cert);

                        return new[] { key };
                    },
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = true // Asegura que el token no haya expirado
                },
                /*
                // Hook para la validación del id_token
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = context =>
                    {
                        // Verificar el id_token aquí
                        ValidateIdToken(context);

                        return Task.CompletedTask;
                    }
                }
                */
            });

            
        }
        /*
        private void ValidateIdToken(OAuthValidateIdentityContext context)
        {
            var idToken = context.Ticket.Identity.FindFirst(c => c.Type == "id_token")?.Value;

            if (string.IsNullOrEmpty(idToken))
            {
                context.Rejected();//falta el id_token
                return;
            }

            // Verificar firma y validar claims específicos del id_token aquí

            // si verifica lee los claims
            var subClaim = context.Ticket.Identity.FindFirst("sub");
            if (subClaim != null)
            {
                // Accede al subject (sub) del id_token
                var subValue = subClaim.Value;
                // Realiza acciones según el sub, por ejemplo, identificar al usuario
            }

            // más validacionesdes

            // si pasan las validades se aprueba la identidad
            context.Validated();
        }
        */
    }
}
