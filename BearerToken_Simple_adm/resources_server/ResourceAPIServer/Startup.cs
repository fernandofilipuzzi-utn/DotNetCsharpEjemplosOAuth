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
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using ResourceAPIServer.AuthBearerTokenUtils;

[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            /*es modificar la respuesta del middleware*/
            //app.Use(typeof(ResponseMiddleware));
            
            Configure(app);
        }

        private void Configure(IAppBuilder app)
        {
            string secretKey = "secret".Sha256();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Sin desplazamiento de tiempo permitido
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters,
                Provider = new OAuthBearerAuthenticationProvider
                {
                    OnValidateIdentity = async context =>
                    {
                        var token = context.Request.Headers.Get("Authorization");

                        if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                        {
                            var tokenString = token.Substring("Bearer ".Length).Trim();
                            var tokenHandler = new JwtSecurityTokenHandler();

                            try
                            {
                                var principal = tokenHandler.ValidateToken(tokenString, tokenValidationParameters, out var validatedToken);

                                var jwtToken = (JwtSecurityToken)validatedToken;
                                if (!jwtToken.Payload.TryGetValue("guid1", out var guid)) //|| guid.ToString() != "expectedGuid")
                                {
                                     return;
                                }
                                else
                                {
                                    context.OwinContext.Request.User = principal;
                                }
                            }
                            catch (Exception ex)
                            {
                                return;
                            }
                        }
                    }
                }
            });
        }
    }
}

