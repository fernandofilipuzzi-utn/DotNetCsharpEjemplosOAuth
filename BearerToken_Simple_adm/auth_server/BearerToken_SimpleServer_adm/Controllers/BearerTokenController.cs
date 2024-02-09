using BearerToken_Models.Models;
using BearerToken_Services.Services;
using BearerToken_SimpleServer_adm.Models;
using BearerToken_SimpleServer_adm.ScopeAuthorizeAttribute;
using BearerToken_SimpleServer_adm.Utils;
using Microsoft.Ajax.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using BearerToken_SimpleServer_adm.ScopeAuthorizeAttribute;

namespace BearerToken_SimpleServer_adm
{
    [RoutePrefix("auth")]
    public class BearerTokenController : ApiController
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
        public IHttpActionResult PostToken(RequestToken request)
        {
            try
            {
                Configure();

                /* acceso sin a los parametros sin formato
                 accede a los parametros al cuerpo de la solicitud - ej: guid=sdffd&frase=sdfsdf
                string guid = HttpContext.Current.Request.Form["guid"];
                string frase = HttpContext.Current.Request.Form["frase"];
                */
                /*
                 accede a los parametros al encabezado - ej: guid=sdffd&frase=sdfsdf
                string guid = Request.Headers.GetValues("guid").FirstOrDefault();
                string clave = Request.Headers.GetValues("clave").FirstOrDefault();
                
                if (string.IsNullOrWhiteSpace(guid) || string.IsNullOrWhiteSpace(frase))
                {
                    return BadRequest();
                }
                CredencialClienteAPI credencial = _validador.ValidarCredenciales(guid, frase);
                */
                if (string.IsNullOrWhiteSpace(request.GUID) || string.IsNullOrWhiteSpace(request.Clave))
                {
                    return BadRequest();
                }
                CredencialClienteAPI credencial = _validador.ValidarCredenciales(request.GUID, request.Clave);

                if (credencial != null)
                {
                    string token = _generador.GenerarToken(request.GUID, credencial.Scopes);
                    return Ok(new { access_token = token, token_type = "Bearer" });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [BearerToken_SimpleServer_adm.ScopeAuthorizeAttribute.ScopeAuthorize]
        [HttpGet]
        [Route("modulos/urls")]
        public IEnumerable<Modulo> GetModulosUrls(string guid)
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                Configure();

                DataTable dtModulos =_validador.moduloDAO.BuscarPorGuidCredencial(guid).Tables[0];
               
                foreach(DataRow dc in dtModulos.Rows)
                {
                    modulos.Add(new Modulo
                    {
                        Id = Convert.ToInt32(dc["id"]),
                        Descripcion = Convert.ToString(dc["descripcion"]),
                        Url = Convert.ToString(dc["url"]),
                    });
                }
            }
            catch (Exception ex)
            {
                   
            }
            return modulos;
        }
    }
}