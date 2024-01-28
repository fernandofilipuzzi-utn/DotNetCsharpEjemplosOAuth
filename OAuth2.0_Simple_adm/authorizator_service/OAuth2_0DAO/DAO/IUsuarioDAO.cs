using OAuth2_0Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2_0DAO.DAO
{
    public interface IUsuarioDAO
    {
        Usuario Agregar(Usuario Nuevo);
        void Actualizar(Usuario Nuevo);
        void Eliminar(int id);
        //
        Usuario BuscarPorId(int id);
        DataTable BuscarTodos();
    }
}
