using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
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
            string _secret = "clave_secreta_mas_larga_y_fuerte";
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(_secret));

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = "https://localhost:44386/api/Ej/MiServicioProtegido",
                    ValidIssuer = "http://localhost:7777/api/token",
                    IssuerSigningKey = securityKey,
                    ClockSkew = TimeSpan.FromMinutes(5)
                }
            });
        }
    }
}
