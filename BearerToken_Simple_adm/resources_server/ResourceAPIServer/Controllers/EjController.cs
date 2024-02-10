using NSwag.Annotations;
using ResourceAPIServer.AuthBearerTokenUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceAPIServer.Controllers
{
    [RoutePrefix("api")]
    public class EjController : ApiController
    {
        [Route("MiServicioNoProtegido")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetMiServicioNoProtegido()
        {
            var userName = this.RequestContext.Principal.Identity.Name;

            return Ok($"¡Bienvenido al servicio no protegido! {userName}");
        }

        [HttpGet]
        //[Authorize]
        //[CustomAuthorize]
        [ScopeAuthorize("api1")]
        [Route("Ejemplos/MiServicioProtegido")]
        public IHttpActionResult GetMiServicioProtegido()
        {
            var user = User.Identity.Name;
            Debug.WriteLine($"Usuario actual: {user}");
            var userName = this.RequestContext.Principal.Identity.Name;

            return Ok($"¡Bienvenido al servicio protegido! {userName}");
        }

        [HttpGet]
        //[Authorize]
        //[CustomAuthorize]
        [ScopeAuthorize("api2")]
        [Route("Ejemplos/MiServicioProtegido2")]
        public IHttpActionResult GetMiServicioProtegido2()
        {
            var user = User.Identity.Name;
            Debug.WriteLine($"Usuario actual: {user}");
            var userName = this.RequestContext.Principal.Identity.Name;

            return Ok($"¡Bienvenido al servicio protegido! {userName}");
        }
    }
}
