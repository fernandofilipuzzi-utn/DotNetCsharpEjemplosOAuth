using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_Models.Models
{
    public class CredencialClienteAPI
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Clave { get; set; }
        public bool Habilitado { get; set; } = true;
        public string Scopes { get; set; } = "all";
        public List<Modulo> Modulos { get; set; } = new List<Modulo>();

        public bool TieneScope(string scope)
        {
            bool tiene=false;
            if (Scopes != null)
            {
                string [] scopes=Scopes.Split(' ');
                for (int n=0; n<scopes.Length && tiene; n++)
                { 
                    tiene=scopes[n].Trim().ToUpper().Equals(scope.ToUpper());
                }
            }
            return tiene;
        }
    }
}
