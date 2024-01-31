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

[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
                                if (!jwtToken.Payload.TryGetValue("guid", out var guid)) //|| guid.ToString() != "expectedGuid")
                                {
                                    /*
                                    context.Response.StatusCode = 401;
                                    context.Response.ContentType = "application/json";
                                    var errorMessage = new { mensaje = "Unauthorized" };
                                    var json = JsonConvert.SerializeObject(errorMessage);
                                    await context.Response.WriteAsync("{ mensaje:'No autorizado!'}");
                                    context.OwinContext.Response.WriteAsync("{ mensaje:'No autorizado!'}");
                                    */
                                    return;
                                }
                                else
                                {
                                    context.OwinContext.Request.User = principal;
                                }
                            }
                            catch (Exception ex)
                            {
                                /*
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("Unauthorized");
                                */
                                /*
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var errorMessage = new { mensaje = "Unauthorized" };
                                */
                                //var json = JsonConvert.SerializeObject(errorMessage);
                                //await context.Response.cpmContext="{ mensaje:'No autorizado!'}";

                                return;
                            }
                        }
                    }
                }
            });
        }
    }
}

