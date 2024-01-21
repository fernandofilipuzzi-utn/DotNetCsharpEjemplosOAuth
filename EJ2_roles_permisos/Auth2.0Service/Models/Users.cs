using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using static IdentityServer3.Core.Constants;

namespace Auth2._0Service.Models
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
                        new Claim("role", "admin"), // Puedes asignar roles al usuario
                        new Claim("scope", "apiScope1") // Puedes asignar ámbitos al usuario
                    }
                },
                new InMemoryUser
                {
                    Username = "usuario2",
                    Password = "clave123",
                    Subject = "2",
                    Enabled=true
                }
                // Agrega más usuarios según sea necesario
            };
        }
    
    }

}