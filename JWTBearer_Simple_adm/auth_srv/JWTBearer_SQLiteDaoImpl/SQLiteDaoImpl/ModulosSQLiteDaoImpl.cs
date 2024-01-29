using JWTBearer_DAO.DAO;
using JWTBearer_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTBearer_SQLiteDaoImpl.SQLiteDaoImpl
{
    public class ModuloSQLiteDaoImpl : IModuloDAO
    {
        string cadenaConexion = "";

        public ModuloSQLiteDaoImpl(string path)
        {
            this.cadenaConexion = $"Data Source={path};Version=3;";
            Inicializar();
        }

        public ModuloSQLiteDaoImpl() : this(Path.GetFullPath("db/db_auth_jwt_bearer.db"))
        {
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
CREATE TABLE IF NOT EXISTS modulos (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT,
    url TEXT 
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

        public Modulo Agregar(Modulo Nuevo)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Modulo Nuevo)
        {
            throw new NotImplementedException();
        }
        
        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Modulo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet BuscarTodos()
        {
            DataSet ds = new DataSet();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id, descripcion, url
FROM modulos";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    using (var adapter = new SQLiteDataAdapter(query))
                    {
                        adapter.Fill(ds);
                    }
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

            return ds;
        }

    }
}
