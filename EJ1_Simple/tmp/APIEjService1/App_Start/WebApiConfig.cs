using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace APIEjService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            //config.Filters.Add(new AuthorizeAttribute());


            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            //config.MessageHandlers.Add(new TokenValidationHandler());
            // Configuración del middleware de autenticación
            //routeTemplate: "api/{controller}/{id}",

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
