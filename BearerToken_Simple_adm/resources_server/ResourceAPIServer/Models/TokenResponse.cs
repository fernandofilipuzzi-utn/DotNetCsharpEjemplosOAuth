using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAPIServer.Models
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public string error { get; set; }
        public string Message { get; set; }
    }
}