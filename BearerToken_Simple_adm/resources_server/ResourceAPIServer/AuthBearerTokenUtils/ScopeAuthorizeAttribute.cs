﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Security.Claims;
using System.Net;
using System.Net.Http;

namespace ResourceAPIServer.AuthBearerToken
{
    public class ScopeAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly string _scope;

        public ScopeAuthorizeAttribute(string scope)
        {
            _scope = scope;
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { mensaje = "No autenticado" });
                //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No autenticado");
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, new { mensaje = "No autorizado" });
                //actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "No autorizado");
            }
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { mensaje = "No autenticado2" });
                return false;
            }
            
            var scopeClaim = principal.FindFirst("scope");
            
            if (scopeClaim != null && scopeClaim.Value.Contains(_scope))
            {
                return true;
            }

            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { mensaje = "No tiene nada2!" });
            return false;
        }
    }
}