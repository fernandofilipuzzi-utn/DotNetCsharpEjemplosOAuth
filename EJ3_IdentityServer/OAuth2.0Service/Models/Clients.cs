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
            var now = DateTime.Now;
            var expirationTime = now.AddMinutes(20); // Ajusta el tiempo de expiración según tus necesidades
            var accessTokenLifetimeInSeconds = (int)(expirationTime - now).TotalSeconds;

            return new List<Client>
                    {
                        new Client
                        {
                            ClientName="melania trump",
                            ClientId = "client1",
                            ClientSecrets = {new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowAccessToAllScopes= true,
                            Flow=Flows.ResourceOwner,//ResourceOwner,//Flow=Flows.Custom
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                        },
                        new Client
                        {
                            ClientName="john nada",
                            ClientId = "client2",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowedScopes = { "api1" },
                            //Flow=Flows.Custom
                            Flow=Flows.ResourceOwner,
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                        },
                        new Client
                        {
                            ClientName="chicholina",
                            ClientId = "client3",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowedScopes = { "api2" },
                            //Flow=Flows.Custom
                            Flow=Flows.ResourceOwner,
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                        },
                        //otros clientes
                    };
        }
    }

}