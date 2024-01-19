using APIEjService.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            string issuer = "http://localhost:7777/api/token";
            string audience = "http://localhost:7778/api/Ej/MiServicioProtegido";
            string secretKey = "clave_secreta_mas_larga_y_fuerte";

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey)),
                ClockSkew = TimeSpan.FromMinutes(5)
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {

                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters,
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = context =>
                    {
                        // Obtener información detallada del token para depuración
                        var token = context.Ticket?.Identity?.BootstrapContext as string;
                        Console.WriteLine($"Token recibido: {token}");

                        // Puedes personalizar el manejo de error aquí
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        context.Response.Write("{'error': 'Token no válido'}");

                        return Task.FromResult<object>(null);
                    }
                }
            });

        }
    }
}
