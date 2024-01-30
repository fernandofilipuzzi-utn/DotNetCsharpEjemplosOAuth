using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAPIServer.Filters
{
    public class HttpTrafficLogger : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        public void Dispose()
        {
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var request = application.Context.Request;
            // Log request details
            Console.WriteLine($"Incoming Request: {request.HttpMethod} {request.Url}");
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var response = application.Context.Response;
            // Log response details
            Console.WriteLine($"Outgoing Response: {response.StatusCode}");
        }
    }
}