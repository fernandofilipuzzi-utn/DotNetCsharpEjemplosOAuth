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
    public class UsuarioSQLiteDaoImpl : IUsuarioDAO
    {
        
        string cadenaConexion = "";

        public UsuarioSQLiteDaoImpl()
        {
            string path = Path.GetFullPath("../../db_oauth2_0.db");
            cadenaConexion = $"Data Source={path};Version=3;";

            //no es recomendable llamar aquí!, necesito otra cosa
            Inicializar();
        }
        public UsuarioSQLiteDaoImpl(string path)
        {
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
            SQLiteConnection conn =null;
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

                //agregar los campos que faltan
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
                    
                    if( dataReader.Read() )
                    {
                        #region nombre
                        string nombre="";
                        if (dataReader["nombre"] != DBNull.Value)
                            nombre = dataReader["nombre"] as string;
                        #endregion

                        #region clave
                        string clave = "";
                        if (dataReader["clave"] != DBNull.Value)
                            clave = dataReader["clave"] as string;
                        #endregion

                        buscado = new Usuario { Id = idBuscado, Nombre=nombre, Clave=clave };
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
            List<Encuesta> encuestas = new List<Encuesta>();

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, nombre, clave 
from usuarios
order by id asc";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
                        #endregion

                        #region nombre
                        int anio = 0;
                        if (dataReader["anio"] != DBNull.Value)
                            anio = Convert.ToInt32(dataReader["anio"]);
                        #endregion

                        #region localidad
                        string localidad = "";
                        if (dataReader["localidad"] != DBNull.Value)
                            localidad = dataReader["localidad"] as string;
                        #endregion

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio, EnCurso = enCurso };
                        encuestas.Add(encuesta);
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
            return encuestas;
        }
    }
}
