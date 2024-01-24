using ResourceAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Identity.Web;

namespace ResourceAPIServer.Controllers
{
    public class EjController : ApiController
    {
        const string scopeRequiredByApi = "access_as_user";

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult MiServicioNoProtegido()
        {
            var userName = this.RequestContext.Principal.Identity.Name;

            return Ok($"¡Bienvenido al servicio no protegido! {userName}");
        }

        [HttpGet]
        //[CustomAuthorize]
        //[Authorize(Roles ="api1")]
        [CustomScopeAuthorizeAttribute("api1")]
        public IHttpActionResult MiServicioProtegido()
        {
            var user = User.Identity.Name;
            Debug.WriteLine($"Usuario actual: {user}");
            var userName = this.RequestContext.Principal.Identity.Name;
            return Ok($"¡Bienvenido al servicio protegido! {userName}");
        }
    }
}
