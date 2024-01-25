using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth2_0AuthorizationServer.Models
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "api1",
                    DisplayName = "My API"
                },
                new Scope
                {
                    Name = "openid",
                    DisplayName = "OPEN ID"
                },
                new Scope
                {
                    Name = "api2",
                    Type=ScopeType.Resource,
                    DisplayName = "My API2",
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("name"),
                        new ScopeClaim("role")
                    }
                },
                //otros alcances
            };
        }
    }

}