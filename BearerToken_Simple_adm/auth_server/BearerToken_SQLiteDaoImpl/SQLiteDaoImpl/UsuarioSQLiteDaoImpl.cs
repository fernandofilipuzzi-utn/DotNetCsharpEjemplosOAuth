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
    public class UsuarioSQLiteDaoImpl : IUsuarioDAO
    {
        string cadenaConexion = "";

        public UsuarioSQLiteDaoImpl():this(Path.GetFullPath("db/db_auth_jwt_bearer.db"))
        {
        }

        public UsuarioSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3; Pooling=true;";

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
CREATE TABLE IF NOT EXISTS usuarios (
    id INTEGER PRIMARY KEY AUTOINCREMENT, 
    nombre TEXT NOT NULL,
    contraseña TEXT NOT NULL
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

        public void Actualizar(Usuario actual)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
update usuarios 
set nombre=@nombre, 
    clave=@clave, 
where id=@id";

                int rowsaffected = 0;
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("nombre", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("clave", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("id", DbType.Int32));
                    //
                    query.Parameters["nombre"].Value = actual.Nombre;
                    query.Parameters["clave"].Value = actual.Clave;
                    query.Parameters["id"].Value = actual.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected} filas.");
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

        public Usuario Agregar(Usuario nuevo)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert into usuarios (nombre, clave)
values (@nombre, @clave)
RETURNING id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("nombre", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("clave", DbType.String));
                    //
                    query.Parameters["nombre"].Value = nuevo.Nombre;
                    query.Parameters["clave"].Value = nuevo.Clave;
                    //
                    //rowsaffected += query.ExecuteNonQuery();
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

        public void Eliminar(int id)
        {
        }

        public Usuario BuscarPorId(int idBuscado)
        {
            Usuario buscado = null;

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select nombre, clave
from usuarios 
where id=@Id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    query.Parameters["Id"].Value = idBuscado;
                    //
                    SQLiteDataReader dataReader = query.ExecuteReader();

                    if (dataReader.Read())
                    {
                        #region nombre
                        string nombre = "";
                        if (dataReader["nombre"] != DBNull.Value)
                            nombre = dataReader["nombre"] as string;
                        #endregion

                        #region clave
                        string clave = "";
                        if (dataReader["clave"] != DBNull.Value)
                            clave = dataReader["clave"] as string;
                        #endregion

                        buscado = new Usuario { Id = idBuscado, Nombre = nombre, Clave = clave };
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
SELECT id, nombre, clave
FROM usuarios";

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
