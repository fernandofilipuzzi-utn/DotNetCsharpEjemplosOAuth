using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BearerToken_SimpleServer_adm.Models
{
    public class RequestToken
    {
        [JsonProperty("guid", NullValueHandling = NullValueHandling.Ignore)]
        public string GUID { get; set; }

        [JsonProperty("clave", NullValueHandling = NullValueHandling.Ignore)]
        public string Clave { get; set; }
    }
}