using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IdentityServer3.Core.Constants;

namespace Auth2._0Service.Models
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
                    {
                        new Client
                        {
                            ClientId = "client",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  = new List<string> { GrantTypes.Password,GrantTypes.ClientCredentials },
                            AllowedScopes = { "api1" }
                        }
                        // Agrega más clientes según sea necesario
                    };
        }
    }

}