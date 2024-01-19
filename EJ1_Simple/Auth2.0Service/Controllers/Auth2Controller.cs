using Microsoft.IdentityModel.Tokens;
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
        /*        
         $ curl -X POST -d "tu_client_id=valor_del_cliente_id&tu_client_secret=valor_del_cliente_secret&username=user&password=123" http://localhost:6666/api/token
{"access_token":"token_simulado","token_type":"Bearer"}
         * */
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
                //$">{ clientId}<, >{ clientSecret}<"; // 
                //GenerarToken(clientId, clientSecret);
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
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("clave_secreta_mas_larga_y_fuerte"));


            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:7777/api/token",
                audience: "http://localhost:7778/api/Ej/MiServicioProtegido",
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}


/*

            // Generar una clave de 256 bits (32 bytes)
            byte[] keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            var securityKey = new SymmetricSecurityKey(keyBytes);
            
private string GenerarToken(string clientId, string clientSecret)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(clientSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:7777/api/token",
                audience: "http://localhost:7778/api/*",
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
     

        fernando @tsp MINGW64 ~ $ curl -X POST -H "Content-Type: application/json" -d '{"tu_client_id": "tu_cliente_id", "tu_client_secret": "tu_cliente_secret", "username": "user", "password": "123"}' http://localhost:6666/api/token
        {"access_token":"token_simulado","token_type":"Bearer"}
     

[HttpPost]
[Route("api/token")]
public HttpResponseMessage GetToken([FromBody] TokenRequestModel request)
{

    string clientId = request.tu_client_id;
    string clientSecret = request.tu_client_secret;
    string username = request.username;
    string password = request.password;

    if (ValidarCredenciales(username, password))
    {
        string token = GenerarToken(clientId, clientSecret);
        return Request.CreateResponse(HttpStatusCode.OK, new { access_token = token, token_type = "Bearer" });
    }
    else
    {
        return Request.CreateResponse(HttpStatusCode.BadRequest, "Credenciales inválidas");
    }
}
*/