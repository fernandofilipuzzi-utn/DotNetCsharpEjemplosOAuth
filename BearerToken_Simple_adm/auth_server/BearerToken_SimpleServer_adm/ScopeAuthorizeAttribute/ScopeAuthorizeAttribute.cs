using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;

namespace BearerToken_SimpleServer_adm.ScopeAuthorizeAttribute
{
    public class ScopeAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly string _scope;

        public ScopeAuthorizeAttribute(string scope)
        {
            _scope = scope;
        }

        public ScopeAuthorizeAttribute()
        {
            _scope = "";
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {

            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No autenticado");
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No autorizado");
            }
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                return false;
            }

            var scopeClaim = principal.FindFirst("scope");

            if (string.IsNullOrWhiteSpace(_scope) == false && scopeClaim != null && scopeClaim.Value.Contains(_scope))
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(_scope) == true)
            {
                return true;
            }

            return false;
        }
    }
}