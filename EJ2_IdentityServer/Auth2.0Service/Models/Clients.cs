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
                            ClientId = "tuClienteId",
                            AccessTokenType = AccessTokenType.Reference,
                            Flow = Flows.ClientCredentials,
                            ClientSecrets = new List<Secret> { new Secret("clave_secreta_mas_larga_y_fuerte".Sha256()) },
                            AllowedCustomGrantTypes  = new List<string> { GrantTypes.Password },//GrantTypes.Password
                            AllowedScopes = new List<string> { "apiScope1", "apiScope2" }
                        }
                        // Agrega más clientes según sea necesario
                    };
        }
    }

}