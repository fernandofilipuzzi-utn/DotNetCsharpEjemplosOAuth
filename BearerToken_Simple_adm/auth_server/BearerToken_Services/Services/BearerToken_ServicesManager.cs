using BearerToken_DAO.DAO;
using BearerToken_Models.Models;
using BearerToken_SQLiteDaoImpl.SQLiteDaoImpl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_Services.Services
{
    public class BearerToken_ServicesManager
    {
        public IUsuarioDAO usuarioDAO { get; set; }
        public IModuloDAO moduloDAO { get; set; }
        public ICredencialClienteAPIDAO credencialDAO { get; set; }

        public BearerToken_ServicesManager(string path)
        {
            usuarioDAO = new UsuarioSQLiteDaoImpl(path);
            moduloDAO = new ModuloSQLiteDaoImpl(path);
            credencialDAO = new CredencialClienteAPISQLiteDaoImpl(path);
        }

        public BearerToken_ServicesManager()
        {
            usuarioDAO = new UsuarioSQLiteDaoImpl();
            moduloDAO = new ModuloSQLiteDaoImpl();
            credencialDAO = new CredencialClienteAPISQLiteDaoImpl();
        }

        public void AgregarCredencial(CredencialClienteAPI nuevaCredencia)
        {
            credencialDAO.Agregar(nuevaCredencia);
        }

        public bool ValidarCredenciales(string guid, string frase)
        {
            DataTable dtCredenciales = credencialDAO.BuscarPorGuid(guid, frase).Tables[0];
            return dtCredenciales.Rows.Count==1;
        }
    }
}
