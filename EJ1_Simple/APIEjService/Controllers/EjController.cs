using System;
using System.Collections.Generic;
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
        public IHttpActionResult ServicioNoProtegido()
        {
            return Ok("¡Bienvenido al servicio no protegido!");
        }

        [HttpGet]
        public IHttpActionResult MiServicioProtegido()
        {
            return Ok("¡Bienvenido al servicio protegido!");
        }
    }
}
