using JWTBearer_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTBearer_DAO.DAO
{
    public interface ICredencialClienteDAO
    {
        CredencialCliente Agregar(CredencialCliente Nuevo);
        void Actualizar(CredencialCliente Nuevo);
        void Eliminar(int id);
        //
        CredencialCliente BuscarPorId(int id);
        DataSet BuscarTodos();
    }
}
