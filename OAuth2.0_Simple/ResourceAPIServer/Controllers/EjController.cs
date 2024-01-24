using ResourceAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceAPIServer.Controllers
{
    public class EjController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult MiServicioNoProtegido()
        {
            var userName = this.RequestContext.Principal.Identity.Name;

            return Ok($"¡Bienvenido al servicio no protegido! {userName}");
        }

        [HttpGet]
        [CustomAuthorize]
        public IHttpActionResult MiServicioProtegido()
        {
            var user = User.Identity.Name;
            Debug.WriteLine($"Usuario actual: {user}");
            var userName = this.RequestContext.Principal.Identity.Name;
            return Ok($"¡Bienvenido al servicio protegido! {userName}");
        }
    }
}
