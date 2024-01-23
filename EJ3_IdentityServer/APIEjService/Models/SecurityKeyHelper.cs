using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace APIEjService.Models
{
    public static class SecurityKeyHelper
    {
        public static SymmetricSecurityKey GetKey(string secret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
    }
}