using JWTBearer_Services.Services;
using JWTBearer_SimpleServer.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
    [RoutePrefix("auth")]
    public class JWTController : ApiController
    {
        TokenGenerador _generador = new TokenGenerador();
        JWTBearer_ServicesManager _validador;

        private void Configure() 
        {
            /*
            string pathDb = Request.RequestUri.GetLeftPart(UriPartial.Authority) + Url.Content("~/db/db_auth_jwt_bearer.db");
            JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager(pathDb);
            _validador = new JWTBearer_ServicesManager(pathDb);
            */
            string appPath = HttpRuntime.AppDomainAppPath;
            string pathDb = Path.Combine(appPath, "db/db_auth_jwt_bearer.db");
            _validador = new JWTBearer_ServicesManager(pathDb);
        }

        [HttpPost]
        [Route("token")]
        public HttpResponseMessage GetToken()
        {
            Configure();

            string guid = HttpContext.Current.Request.Form["guid"];
            string frase = HttpContext.Current.Request.Form["frase"];

            if (_validador.ValidarCredenciales(guid, frase))
            {
                string token = _generador.GenerarToken(guid);
                return Request.CreateResponse(HttpStatusCode.OK, new { access_token = token, token_type = "Bearer" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Credenciales inválidas");
            }
        }

        
    }
}