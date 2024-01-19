using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Security.Cryptography;
using System.Text;

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
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("clave_secreta_mas_larga_y_fuerte"));

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = "http://localhost:7778/api/Ej/MiServicioProtegido",
                    ValidIssuer = "http://localhost:7777/api/token",
                    IssuerSigningKey = securityKey
                }
            });
        }
    }
}

/*

private void ConfigureAuth(IAppBuilder app)
{
    var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("clave_secreta_mas_larga_y_fuerte"));

    app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
    {
        TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = "http://localhost:7778/api/Ej/MiServicioProtegido",
            ValidIssuer = "http://localhost:7778/api/token",
            IssuerSigningKey = securityKey
        },
        Provider = new OAuthBearerAuthenticationProvider
        {
            OnTokenValidated = context =>
            {
                // Aquí puedes realizar acciones personalizadas después de validar el token
                // por ejemplo, loguear información sobre el token
                var token = context.SecurityToken as JwtSecurityToken;
                if (token != null)
                {
                    // Accede a las claims del token
                    var username = token.Claims.FirstOrDefault(c => c.Type == "username")?.Value;
                    // Realiza acciones personalizadas según sea necesario

                    // Ejemplo de log:
                    Console.WriteLine($"Token validado para el usuario: {username}");
                }

                return Task.CompletedTask;
            }
        }
    });
}
*/

