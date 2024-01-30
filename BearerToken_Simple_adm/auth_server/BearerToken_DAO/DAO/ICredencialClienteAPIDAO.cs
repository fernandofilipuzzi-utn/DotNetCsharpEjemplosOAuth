using BearerToken_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_DAO.DAO
{
    public interface ICredencialClienteAPIDAO
    {
        CredencialClienteAPI Agregar(CredencialClienteAPI Nuevo);
        void Actualizar(CredencialClienteAPI Nuevo);
        void Eliminar(int id);
        //
        CredencialClienteAPI BuscarPorId(int id);
        DataSet BuscarTodos();
        DataSet BuscarPorGuid(string guid, string clave);
    }
}
