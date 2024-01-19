//using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Auth2._0Service.Controllers
{
    public class Auth2Controller : ApiController
    {
        [HttpPost]
        [Route("api/token")]
        public HttpResponseMessage GetToken()
        {
            #region credenciales del cliente (aplicación cliente)
            string clientId = HttpContext.Current.Request.Form["client_id"];
            string clientSecret = HttpContext.Current.Request.Form["client_secret"];
            #endregion
            string username = HttpContext.Current.Request.Form["username"];
            string password = HttpContext.Current.Request.Form["password"];
            
            if (ValidarCredenciales(username, password))
            {
                string token = GenerarToken();
                return Request.CreateResponse(HttpStatusCode.OK, new { access_token = token, token_type = "Bearer" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Credenciales inválidas");
            }
        }

        private bool ValidarCredenciales(string username, string password)
        {
            // implementar consulta a la bd
            return username == "user" && password == "123";
        }

        private string GenerarToken()
        {
            string secretKey = "clave_secreta_mas_larga_y_fuerte"; ;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:7777/api/token",
                audience: "https://localhost:44386/api/Ej/MiServicioProtegido",
                expires: DateTime.Now.AddDays(199),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}