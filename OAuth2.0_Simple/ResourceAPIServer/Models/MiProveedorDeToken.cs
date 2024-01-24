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
            // Validar las credenciales del cliente aquí
            string clientId = "client_id";// context.ClientId;
            string clientSecret = "client_secret";// context.ClientSecret;

            // Ejemplo básico de validación, debes implementar la lógica de acuerdo a tus necesidades
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
            // Validar las credenciales del usuario aquí
            string username = context.UserName;
            string password = context.Password;

            // Ejemplo básico de validación, debes implementar la lógica de acuerdo a tus necesidades
            if (username == "user" && password == "123")
            {
                // Generar el token de acceso
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