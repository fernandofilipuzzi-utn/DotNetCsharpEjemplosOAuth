using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace OAuth2_0AuthorizationServer.Models
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _guid;
        private readonly string _frase;

        public CustomOAuthProvider(string guid, string frase)
        {
            _guid = guid;
            _frase = frase;
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Verificar las credenciales del usuario y generar el token JWT si son válidas
            if (!ValidateUserCredentials(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "El nombre de usuario o la contraseña son incorrectos");
                return Task.CompletedTask;
            }

            // Crear los claims del usuario
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, context.UserName),
            new Claim("guid", _guid) // Agregar el GUID como claim
        };

            // Configurar la clave de seguridad
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_frase));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crear el token JWT
            var token = new JwtSecurityToken(
                issuer: "MiEmpresa",
                audience: "MiCliente",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            // Escribir el token JWT en el contexto de OAuth
            context.Validated(new AuthenticationTicket(new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType), new AuthenticationProperties()));

            return Task.CompletedTask;
        }

        private bool ValidateUserCredentials(string username, string password)
        {
            // Lógica de validación de credenciales de usuario
            // Retorna true si las credenciales son válidas, de lo contrario false
            return true;
        }
    }
}