using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Security.Claims;
namespace ResourceAPIServer.Models
{
    public class CustomScopeAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        private readonly string _scope;

        public CustomScopeAuthorizeAttribute(string scope)
        {
            _scope = scope;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                return false;
            }
            
            var scopeClaim = principal.FindFirst("scope");
            
            if (scopeClaim != null && scopeClaim.Value.Contains(_scope))
            {
                return true;
            }

            return false;
        }
    }
}