using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace APIEjService.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                // Usuario no autenticado
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No autenticado");
            }
            else
            {
                // Usuario autenticado pero no autorizado
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No autorizado");
            }
        }
    }
}