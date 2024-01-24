using ResourceAPIServer.Models;
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
using System.Web.Http;
using ResourceAPIServer.Utils;

//[assembly: OwinStartupAttribute(typeof(AuthenticatedAPIEjService.Startup))]
//[assembly: OwinStartup("ProductionConfiguration", AuthenticatedAPIEjService.Startup)]
[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
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
            // Configuración para consumir el token en la API protegida
            var issuer = "http://localhost:7777/identity/connect/token";
            var audience = "http://localhost:7778/api/Ej/MiServicioProtegido";
            var secretKey = "secret".Sha256();

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.FromMinutes(5)
                }
            });
        }
    }
}
