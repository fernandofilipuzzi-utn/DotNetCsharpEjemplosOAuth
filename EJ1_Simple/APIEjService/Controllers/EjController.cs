using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIEjService.Controllers
{
    [Authorize]
    public class EjController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult MiServicioNoProtegido()
        {
            

            return Ok("¡Bienvenido al servicio no protegido!");
        }

        [HttpGet]
        public IHttpActionResult MiServicioProtegido()
        {
            var user = User.Identity.Name;
            Debug.WriteLine($"Usuario actual: {user}");

            return Ok("¡Bienvenido al servicio protegido!");
        }
    }
}
