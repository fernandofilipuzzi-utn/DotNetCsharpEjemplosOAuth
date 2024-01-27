using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using static IdentityServer3.Core.Constants;

namespace OAuth2_0AuthorizationServer.Models
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
          
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Username = "usuario1",
                    Password = "clave123",
                    Subject = "1",
                    Enabled=true,
                    Claims = new List<Claim>
                    {
                        new Claim(Constants.ClaimTypes.Role, "admin"), 
                        new Claim(Constants.ClaimTypes.Scope, "openid api1"),
                        new Claim(Constants.ClaimTypes.Email, "john@example.org"),
                        new Claim(Constants.ClaimTypes.Audience, "http://prueba.com"),
                        new Claim("x-domain", "foo") 
                    }
                },
                new InMemoryUser
                {
                    Username = "usuario2",
                    Password = "clave123",
                    Subject = "2",
                    Enabled=true,
                    Claims = new List<Claim>
                    {
                        new Claim("role", "admin"),
                        new Claim("scope", "api1"),
                        new Claim("email", "john@example.org"),
                        new Claim("x-domain", "foo")
                    }
                }
                ,
                new InMemoryUser
                {
                    Username = "usuario3",
                    Password = "clave123",
                    Subject = "3",
                    Enabled=true,
                }
                // Agrega más usuarios
            };
        }
    
    }

}