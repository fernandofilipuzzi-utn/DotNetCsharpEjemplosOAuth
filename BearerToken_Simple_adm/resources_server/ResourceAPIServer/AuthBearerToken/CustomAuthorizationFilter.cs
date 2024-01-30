using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace ResourceAPIServer.AuthBearerToken
{
    public class CustomAuthorizationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            //logica de autentificacion
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            //verificar  si fue denegada y modificar la respuesta en consecuencia
            if (context.ActionContext.Response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Acceso no autorizado"),
                    RequestMessage = context.Request
                };

                context.Result = new CustomUnauthorizedResult(response, context.Request);
            }
        }
    }
}