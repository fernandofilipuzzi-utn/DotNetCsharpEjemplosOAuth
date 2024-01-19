using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth2._0Service.Models
{
    public class TokenRequestModel
    {
        public string tu_client_id { get; set; }
        public string tu_client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}