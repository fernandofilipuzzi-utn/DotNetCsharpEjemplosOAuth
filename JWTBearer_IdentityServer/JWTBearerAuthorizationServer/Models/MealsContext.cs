using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth2_0AuthorizationServer.Models
{
    public class MealsContext
    {
        /*
        public DbSet<User> Users { get; set; }

        // Constructor and configuration...

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure entity mappings...
        }
        */
        public List<User> Users { get; set; }

        public MealsContext()
        {
            // Inicializa la lista de usuarios con algunos valores harcodeados
            Users = new List<User>
            {
                new User { guid = "usuario1", clave="IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw" }, 
                //
            };
        }
    }
}