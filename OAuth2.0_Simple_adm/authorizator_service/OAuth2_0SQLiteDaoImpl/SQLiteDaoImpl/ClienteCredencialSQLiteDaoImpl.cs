using OAuth2_0DAO.DAO;
using OAuth2_0Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2_0SQLiteDaoImpl.SQLiteDaoImpl
{
    public class ClienteCredencialSQLiteDaoImpl : IClienteCredencialDAO
    {
        string cadenaConexion = "";

        public ClienteCredencialSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3;";
            Inicializar();
        }

        public ClienteCredencialSQLiteDaoImpl()
        {
            string path= Path.GetFullPath("../../db_oauth2_0.db");
            cadenaConexion = $"Data Source={path};Version=3;";

            //no es recomendable llamar aquí!, necesito otra cosa
            Inicializar();
        }

        private void Inicializar()
        {
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS clientes_credenciales (
    id INTEGER PRIMARY KEY AUTOINCREMENT 
)";
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public ClienteCredencial Agregar(ClienteCredencial Nuevo)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(ClienteCredencial Nuevo)
        {
            throw new NotImplementedException();
        }

        ClienteCredencial IClienteCredencialDAO.BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        DataTable IClienteCredencialDAO.BuscarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
