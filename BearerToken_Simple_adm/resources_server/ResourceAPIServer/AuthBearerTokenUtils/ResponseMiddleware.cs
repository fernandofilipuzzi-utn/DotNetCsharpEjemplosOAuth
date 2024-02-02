using Microsoft.Owin;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ResourceAPIServer.AuthBearerTokenUtils
{
    public class ResponseMiddleware : OwinMiddleware
    {
        public ResponseMiddleware(OwinMiddleware next) : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            /*modifica todas
            if (context.Response.StatusCode != 200)
            {
                var newContext = new OwinContext(context.Environment);
                newContext.Response.StatusCode = 401;
                newContext.Response.ContentType = "application/json";
                await newContext.Response.WriteAsync("{ mensaje:'No autorizado!'}");

                await Next.Invoke(context);
            }
            else
            {
                await Next.Invoke(context);
            }
            */

            if (context.Request.Path.StartsWithSegments(new PathString("/api")) && context.Response.StatusCode != 200)
            {
                var newContext = new OwinContext(context.Environment);
                newContext.Response.StatusCode = 401;
                newContext.Response.ContentType = "application/json";
                await newContext.Response.WriteAsync("{ mensaje:'No autorizado!'}");

                await Next.Invoke(context);
            }
            else
            {
                await Next.Invoke(context);
            }
        }
    }
}