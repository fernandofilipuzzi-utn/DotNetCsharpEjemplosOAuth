using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth2._0Service.Models
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope
                {
                    Name = "apiScope1",
                    DisplayName = "API Scope 1"
                },
                new Scope
                {
                    Name = "apiScope2",
                    DisplayName = "API Scope 2"
                }
                // Agrega más ámbitos según sea necesario
            };
        }
    }

}