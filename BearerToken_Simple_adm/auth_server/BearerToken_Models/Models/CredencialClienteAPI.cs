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
    }
}
