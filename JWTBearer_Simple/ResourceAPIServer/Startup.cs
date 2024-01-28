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
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
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
                        Console.WriteLine(ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }

                await next.Invoke();
            });
        }
    }
}
