using BearerToken_DAO.DAO;
using BearerToken_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken_SQLiteDaoImpl.SQLiteDaoImpl
{
    public class CredencialClienteSQLiteDaoImpl : ICredencialClienteDAO
    {
        string cadenaConexion = "";

        public CredencialClienteSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3;";
            Inicializar();
        }

        public CredencialClienteSQLiteDaoImpl():this(Path.GetFullPath("db/db_auth_jwt_bearer.db"))
        {
        }

        private void Inicializar()
        {
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS credenciales_clientes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    guid TEXT UNIQUE,
    clave TEXT NOT NULL,
    habilitado INTEGER CHECK (habilitado IN (0, 1)),
    scopes TEXT NOT NULL
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

        public CredencialCliente Agregar(CredencialCliente nueva)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
INSERT INTO credenciales_clientes (guid, clave, habilitado, scopes)
VALUES (@Guid, @Clave, @Habilitado,@Scopes)
RETURNING id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Guid", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("Clave", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("Habilitado", SqlDbType.Bit));
                    query.Parameters.Add(new SQLiteParameter("Scopes", DbType.String));
                    //
                    query.Parameters["Guid"].Value = nueva.Guid;
                    query.Parameters["Clave"].Value = nueva.Clave;
                    query.Parameters["Habilitado"].Value = nueva.Habilitado ? 1 : 0;
                    query.Parameters["Scopes"].Value = nueva.Scopes;
                    //
                    object id = query.ExecuteScalar();
                    nueva.Id = Convert.ToInt32(id);
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
            return nueva;
        }

        public void Actualizar(CredencialCliente Nuevo)
        {
            throw new NotImplementedException();
        }
        
        public void Eliminar(int id)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
DELETE FROM credenciales_clientes
WHERE id = @Id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    //
                    query.Parameters["Id"].Value = id;
                    //
                    int rows=query.ExecuteNonQuery();
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

        public CredencialCliente BuscarPorId(int idBuscado)
        {
            CredencialCliente buscado = null;

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id, guid, clave, habilitado, scopes
FROM credenciales_clientes
WHERE id=@Id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    query.Parameters["Id"].Value = idBuscado;
                    //
                    SQLiteDataReader dataReader = query.ExecuteReader();

                    if (dataReader.Read())
                    {
                        #region guid
                        string guid = "";
                        if (dataReader["guid"] != DBNull.Value)
                            guid = Convert.ToString( dataReader["guid"] );
                        #endregion

                        #region clave
                        string clave = "";
                        if (dataReader["clave"] != DBNull.Value)
                            clave = Convert.ToString( dataReader["clave"] );
                        #endregion

                        #region habilitado
                        bool habilitado = false;
                        if (dataReader["habilitado"] != DBNull.Value)
                            habilitado = Convert.ToBoolean(dataReader["habilitado"]);
                        #endregion

                        #region scopes
                        string scopes = "";
                        if (dataReader["scopes"] != DBNull.Value)
                            scopes = Convert.ToString(dataReader["scopes"]);
                        #endregion

                        buscado = new CredencialCliente { Id = idBuscado, Guid = guid, Clave = clave, Habilitado=habilitado, Scopes=scopes };
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
            return buscado;
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
SELECT id, guid, clave, habilitado, scopes
FROM credenciales_clientes";

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

        public DataSet BuscarPorGuid(string guid, string clave)
        {
            DataSet ds = new DataSet();
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
SELECT id, guid, clave, habilitado, scopes
FROM credenciales_clientes
WHERE guid=@Guid and clave=@Clave";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Guid", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("Clave", DbType.String));
                    //
                    query.Parameters["Guid"].Value = guid;
                    query.Parameters["Clave"].Value = clave;
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
