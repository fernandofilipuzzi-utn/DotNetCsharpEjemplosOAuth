using DTO_lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace signningSimple.Cliente.Controllers
{
    [RoutePrefix("api/Registre")]
    public class LoginExternoController : ApiController
    {
        [HttpPost]
        [Route("Registre")]
        public DTO_Respuesta PostLogin([FromBody] DTO_Ciudadano Ciudadano)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");

            var respuesta= new DTO_Respuesta();
            respuesta.Codigo = ResultCode.Success;
            respuesta.Mensaje = "Login exitoso.";
            respuesta.Datos = Guid.NewGuid().ToString("N");

            return respuesta;
        }
    }
}
