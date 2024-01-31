using BearerToken_Models.Models;
using BearerToken_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer.Admin
{
    public partial class credenciales_edicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);

            if (IsPostBack == false)
            {
                if (string.IsNullOrWhiteSpace(Request["Id"])==false)
                {
                    int id = Convert.ToInt32(Request["Id"]);
                    CredencialClienteAPI credencial = oservice.credencialDAO.BuscarPorId(id);

                    tbIdCredencial.Text = credencial.Id.ToString();
                    tbGuid.Text=credencial.Guid;
                    tbClave.Text = credencial.Clave;
                    tbScopes.Text = credencial.Scopes;

                    actualizarVistaModulos(credencial.Id);
                }
                else
                {
                    tbGuid.Text = Guid.NewGuid().ToString();
                }
            }
        }

        protected void btnConfirmarEdicionCredencial_Click(object sender, EventArgs e)
        {
            string guid = tbGuid.Text;
            string clave = tbClave.Text;
            string scopes = tbScopes.Text;

            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            CredencialClienteAPI nuevaCredencial = new CredencialClienteAPI { Guid = guid, Clave=clave, Scopes= scopes };
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);

            oservice.AgregarCredencial(nuevaCredencial);
        }

        protected void lvModulos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void lBtnAgregarNuevoModulo_Click(object sender, EventArgs e)
        {
            TextBox tbId = lvModulos.InsertItem.FindControl("tbId") as TextBox;
            TextBox tbDescripcion = lvModulos.InsertItem.FindControl("tbDescripcion") as TextBox;
            TextBox tbURL = lvModulos.InsertItem.FindControl("tbURL") as TextBox;

            int idCredencial=Convert.ToInt32(tbIdCredencial.Text);

            if (tbDescripcion != null && tbURL != null)
            {
                string descripcion = tbDescripcion.Text;
                string url = tbURL.Text;

                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
                Modulo nuevo = new Modulo { Descripcion = descripcion, Url = url };
                oservice.moduloDAO.Agregar(nuevo, idCredencial);

                actualizarVistaModulos(idCredencial);
            }
        }

        protected void lbtnEdEliminarModulo_Click(object sender, EventArgs e)
        {
            int idModulo =Convert.ToInt32(tbIdCredencial.Text);

            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);

            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
                
            oservice.moduloDAO.Eliminar(idModulo);

            actualizarVistaModulos(idCredencial);
        }

        protected void lbtnEdModificarModulo_Click(object sender, EventArgs e)
        {
            TextBox tbEdIdModulo = lvModulos.InsertItem.FindControl("tbEdIdModulo") as TextBox;
            TextBox tbEdDescripcionModulo = lvModulos.InsertItem.FindControl("tbEdDescripcionModulo") as TextBox;
            TextBox tbEdUrlModulo = lvModulos.InsertItem.FindControl("tbEdUrlModulo") as TextBox;

            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);

            if (tbEdIdModulo!=null && tbEdDescripcionModulo != null && tbEdUrlModulo!=null)
            {
                int id = Convert.ToInt32(tbEdIdModulo.Text.Trim());
                string descripcion = tbEdIdModulo.Text.Trim();
                string url = tbEdIdModulo.Text.Trim();

                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);

                oservice.moduloDAO.Actualizar(new Modulo { Id = id, Descripcion = descripcion, Url = url });

                actualizarVistaModulos(idCredencial);
            }
        }

        private void actualizarVistaModulos(int idCredencial)
        {
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
            lvModulos.DataSource = oservice.moduloDAO.BuscarPorIdCredencial(idCredencial).Tables[0];
            lvModulos.DataBind();
        }
    }
}