//using Microsoft.IdentityModel.Tokens;
using JWTBearer_SimpleServer.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace JWTBearer_SimpleServer
{
    [RoutePrefix("identity")]
    public class OAuth2Controller : ApiController
    {
        [HttpPost]
        [Route("token")]
        public HttpResponseMessage GetToken()
        {
            string guid = HttpContext.Current.Request.Form["guid"];
            string frase = HttpContext.Current.Request.Form["frase"];

            if (ValidarCredenciales(guid, frase))
            {
                string token = GenerarToken(guid);
                var response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(token, Encoding.UTF8, "application/jwt");
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Credenciales inválidas");
            }
        }

        private bool ValidarCredenciales(string guid, string frase)
        {
            return guid == "guid" && frase == "frase";
        }

        private string GenerarToken(string guid)
        {
            string secretKey = "secret".Sha256(); 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                    new Claim("guid", guid)
                };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}