using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ResourceAPIServer.Models
{
    public class MiProveedorDeToken : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            
            string clientId = "client_id";// context.ClientId;
            string clientSecret = "client_secret";// context.ClientSecret;

            // Ejemplo básico de validación
            if (clientId == "client_id" && clientSecret == "client_secret")
            {
                context.Validated();
            }
            else
            {
                context.SetError("invalid_client", "Credenciales de cliente inválidas");
                context.Rejected();
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string username = context.UserName;
            string password = context.Password;

            if (username == "user" && password == "123")
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                var ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
                context.Validated(ticket);
            }
            else
            {
                context.SetError("invalid_grant", "Credenciales de usuario inválidas");
                context.Rejected();
            }
        }
    }
}