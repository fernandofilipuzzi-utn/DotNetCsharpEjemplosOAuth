using OAuth2_0Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2_0DAO.DAO
{
    public interface IClienteCredencialDAO
    {
        ClienteCredencial Agregar(ClienteCredencial Nuevo);
        void Actualizar(ClienteCredencial Nuevo);
        void Eliminar(int id);
        //
        ClienteCredencial BuscarPorId(int id);
        DataTable BuscarTodos();
    }
}
