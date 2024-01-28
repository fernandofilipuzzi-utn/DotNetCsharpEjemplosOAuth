using OAuth2_0DAO.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2_0Servicio.Services
{
    public class OAuth2_0Manager
    {
        public IUsuarioDAO usuarioDAO { get; set; }
        public IClienteCredencialDAO credencialDAO { get; set; } 
        
        public OAuth2_0Manager()
        {

            usuarioDAO = new UsuarioSQLiteDaoImpl();
            credencialDAO = new ClienteCredencialSQLiteDaoImpl();
        }

    }
}
