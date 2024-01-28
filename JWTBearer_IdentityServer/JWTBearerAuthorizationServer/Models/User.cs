using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth2_0AuthorizationServer.Models
{
    public class User : IdentityUser
    {
        public string guid { get; set; }
        public string clave { get; set; }
    }
}