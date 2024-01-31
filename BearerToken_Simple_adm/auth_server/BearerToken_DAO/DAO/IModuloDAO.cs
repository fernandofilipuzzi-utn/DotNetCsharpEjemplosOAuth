using BearerToken_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_DAO.DAO
{
    public interface IModuloDAO
    {
        Modulo Agregar(Modulo Nuevo, int idCredencial);
        void Actualizar(Modulo Nuevo);
        void Eliminar(int id);
        //
        Modulo BuscarPorId(int id);
        DataSet BuscarTodos();
        DataSet BuscarPorIdCredencial(int idCredencial);
        DataSet BuscarPorGuidCredencial(string guid);
    }
}
