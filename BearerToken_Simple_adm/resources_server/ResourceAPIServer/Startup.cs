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
using System.IdentityModel.Tokens.Jwt;

[assembly: OwinStartup(typeof(AuthenticatedAPIEjService.Startup))]
namespace AuthenticatedAPIEjService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Configure(app);
        }

        /*
        private void Configure(IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var token = context.Request.Headers.Get("Authorization");

                if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var tokenString = token.Substring("Bearer ".Length).Trim();
                    var tokenHandler = new JwtValidator("secret");

                    try
                    {
                        var principal = tokenHandler.ValidateToken(tokenString, "guid", "frase");
                        context.Request.User = principal;
                    }
                    catch (SecurityTokenValidationException ex)
                    {
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("Unauthorized");
                        return;
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 500; // Cambiado a 500, que es el código de error interno correcto
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("Internal Server Error");
                        return;
                    }
                }

                await next.Invoke();
            });
        }
        */
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
                                if (!jwtToken.Payload.TryGetValue("guid", out var guid) || guid.ToString() != "expectedGuid")
                                {
                                    // Si el GUID no coincide con el esperado, no autenticar al usuario
                                    //context.RejectIdentity();
                                    return;
                                }
                                else
                                {
                                    // Si el token es válido y el GUID es correcto, establecer el usuario en el contexto de OWIN
                                    context.OwinContext.Request.User = principal;
                                }
                            }
                            catch (Exception ex)
                            {
                                // Si hay algún error al validar el token, rechazar la identidad del usuario
                                //context.RejectIdentity();
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync("Unauthorized");
                                return;
                               // Console.WriteLine($"Error al validar el token JWT: {ex.Message}");
                            }
                        }
                    }
                }
            });
        }
    }
}

