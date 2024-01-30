using BearerToken_Services.Services;
using BearerToken_SimpleServer_adm.Utils;
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

namespace BearerToken_SimpleServer_adm
{
    [RoutePrefix("auth")]
    public class JWTController : ApiController
    {
        TokenGenerador _generador = new TokenGenerador();
        BearerToken_ServicesManager _validador;

        private void Configure() 
        {
            /*
            string pathDb = Request.RequestUri.GetLeftPart(UriPartial.Authority) + Url.Content("~/db/db_auth_jwt_bearer.db");
            JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager(pathDb);
            _validador = new JWTBearer_ServicesManager(pathDb);
            */
            string appPath = HttpRuntime.AppDomainAppPath;
            string pathDb = Path.Combine(appPath, "db/db_auth_jwt_bearer.db");
            _validador = new BearerToken_ServicesManager(pathDb);
        }

        [HttpPost]
        [Route("token")]
        public IHttpActionResult GetToken()
        {
            Configure();

            string guid = HttpContext.Current.Request.Form["guid"];
            string frase = HttpContext.Current.Request.Form["frase"];
            if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(frase))
            {
                return BadRequest();
            }

            if (_validador.ValidarCredenciales(guid, frase))
            {

                string token = _generador.GenerarToken(guid, "api1");
                return Ok(new { access_token = token, token_type = "Bearer" });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}