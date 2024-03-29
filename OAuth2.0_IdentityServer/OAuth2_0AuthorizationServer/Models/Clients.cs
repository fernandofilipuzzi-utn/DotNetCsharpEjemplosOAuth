﻿using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static IdentityServer3.Core.Constants;

namespace OAuth2_0AuthorizationServer.Models
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
                            /*no requiere username y pasword*/
                            ClientName="melania trump",
                            ClientId = "client1",
                            ClientSecrets = {new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  { GrantTypes.Password,GrantTypes.ClientCredentials/*client_credentials*/ },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            //AllowAccessToAllScopes= true,
                            Flow=Flows.ClientCredentials,//ResourceOwner,//ResourceOwner,//Flow=Flows.Custom
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                            AllowedScopes = { "openid", "api1", "api2" },
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
                            ClientName="john nada",
                            ClientId = "client4",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  =  {GrantTypes.ClientCredentials },
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowedScopes = { "api1" },
                            Flow=Flows.ClientCredentials,
                            AlwaysSendClientClaims=true,
                            ClientUri="http://jonh.org",
                            IncludeJwtId=true,
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                        },
                        new Client
                        {
                            ClientName="chicholina",
                            ClientId = "client3",
                            ClientSecrets = { new Secret("secret".Sha256()) },
                            AllowedCustomGrantTypes  = { GrantTypes.AuthorizationCode },  // Cambia aquí el tipo de concesión
                            RedirectUris = { "http://localhost:7777/identity/callback" },   // Agrega las URI de redirección adecuadas
                            PostLogoutRedirectUris = { "http://localhost:7777/identity/logout" },  // Agrega las URI de redirección adecuadas
                            Enabled=true,
                            AccessTokenType=AccessTokenType.Jwt,
                            AllowedScopes = { "api1", "openid" },
                            AccessTokenLifetime=accessTokenLifetimeInSeconds,
                            AlwaysSendClientClaims=true,
                        },

                        //otros clientes
                    };
        }
    }

}