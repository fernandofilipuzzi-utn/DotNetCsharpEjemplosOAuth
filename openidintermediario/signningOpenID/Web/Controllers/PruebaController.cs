using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class PruebaController : Controller
    {
        [Route("Prueba")]
        public ActionResult Index()
        {
            return Redirect("/About");
        }

    }
}
