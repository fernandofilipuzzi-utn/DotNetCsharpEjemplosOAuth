using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IdentityServer3.Core.Constants;

namespace OAuth2._0Service.Models
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
         
            return new List<Client>
                    {
                        new Client
                        {
                            ClientId = "client1",
                            ClientSecrets = {new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowAccessToAllScopes= true,
                        },
                        new Client
                        {
                            ClientId = "client2",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials },
                            AllowedScopes = { "api1" }
                        },
                        //otros clientes
                    };
        }
    }

}