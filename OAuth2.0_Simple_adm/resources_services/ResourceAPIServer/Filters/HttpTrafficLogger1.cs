using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ResourceAPIServer.Filters
{
    public class HttpTrafficLogger1 : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            string logPath = Path.Combine(directorioBase, @"logs/log.txt");

            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Information() // Configura el nivel mínimo de log (puedes ajustarlo según sea necesario)
               .WriteTo.File(logPath, rollingInterval: RollingInterval.Day) // Escribe los registros en un archivo llamado "log.txt" y rueda los archivos diariamente
               .CreateLogger();

            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        public void Dispose()
        {
            // Aquí puedes realizar la limpieza si es necesario
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var request = application.Request;

            // Capturar la solicitud entrante
            Log.Information("Incoming Request: {RequestMethod} {RequestUrl}", request.HttpMethod, request.Url);
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var response = application.Response;



            // Capturar la respuesta saliente
            Log.Information("Outgoing Response: {StatusCode} {StatusDescription} {Headers}", response.StatusCode, response.StatusDescription, response.Headers);
        }

        //https://stackoverflow.com/questions/43403941/how-to-read-asp-net-core-response-body
        //https://stackoverflow.com/questions/48396746/asp-net-response-filter-on-the-entire-content-full-response
        //https://weblog.west-wind.com/posts/2009/Nov/13/Capturing-and-Transforming-ASPNET-Output-with-ResponseFilter
    }
}