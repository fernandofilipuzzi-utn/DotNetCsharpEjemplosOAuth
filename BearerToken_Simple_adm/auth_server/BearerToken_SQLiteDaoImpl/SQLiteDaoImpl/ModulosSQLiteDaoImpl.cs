using BearerToken_DAO.DAO;
using BearerToken_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_SQLiteDaoImpl.SQLiteDaoImpl
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
    descripcion TEXT NOT NULL,
    url TEXT NOT NULL,
    id_credencial INTEGER
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

        public Modulo Agregar(Modulo nuevo,int idCredencial)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
INSERT INTO modulos (descripcion, url, id_credencial)
VALUES (@Descripcion, @Url, @IdCredencial)
RETURNING id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Descripcion", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("Url", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("IdCredencial", DbType.Int32));
                    //
                    query.Parameters["Descripcion"].Value = nuevo.Descripcion;
                    query.Parameters["Url"].Value = nuevo.Url;
                    query.Parameters["IdCredencial"].Value = idCredencial;
                    //
                    object id = query.ExecuteScalar();
                    nuevo.Id = Convert.ToInt32(id);
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
            return nuevo;
        }

        public void Actualizar(Modulo modulo)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
UPDATE modulos SET descripcion=@Descripcion, url=@Url
WHERE id=@IdModulo
";
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Descripcion", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("Url", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("IdModulo", DbType.Int32));
                    //
                    query.Parameters["Descripcion"].Value = modulo.Descripcion;
                    query.Parameters["Url"].Value = modulo.Url;
                    query.Parameters["IdModulo"].Value = modulo.Id;
                    //
                    int rows = query.ExecuteNonQuery();
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
        
        public void Eliminar(int id)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
DELETE FROM modulos
WHERE id=@IdModulo
";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("IdModulo", DbType.Int32));
                    //
                    query.Parameters["IdModulo"].Value = id;
                    //
                    int rows = query.ExecuteNonQuery();
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
SELECT id, descripcion, url, id_credencial
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

        public DataSet BuscarPorIdCredencial(int idCredencial)
        {
            DataSet ds = new DataSet();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id, descripcion, url, id_credencial
FROM modulos
WHERE id_credencial=@IdCredencial";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("IdCredencial", DbType.Int32));
                    //
                    query.Parameters["IdCredencial"].Value = idCredencial;
                    //
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

        public DataSet BuscarPorGuidCredencial(string guid)
        {
            DataSet ds = new DataSet();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT mod.id, mod.descripcion, mod.url, mod.id_credencial
FROM modulos as mod
JOIN credenciales_clientes as cred
    on cred.id=mod.id_credencial
WHERE cred.guid=@Guid";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Guid", DbType.String));
                    //
                    query.Parameters["Guid"].Value = guid;
                    //
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
