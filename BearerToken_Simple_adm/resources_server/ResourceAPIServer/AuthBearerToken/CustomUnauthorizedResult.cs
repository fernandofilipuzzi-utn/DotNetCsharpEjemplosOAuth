using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ResourceAPIServer.AuthBearerToken
{
    public class CustomUnauthorizedResult : IHttpActionResult
    {
        private readonly HttpResponseMessage _response;
        private readonly HttpRequestMessage _request;

        public CustomUnauthorizedResult(HttpResponseMessage response, HttpRequestMessage request)
        {
            _response = response;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }
}