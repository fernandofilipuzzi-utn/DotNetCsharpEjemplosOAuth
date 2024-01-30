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
                    CredencialCliente credencial = oservice.credencialDAO.BuscarPorId(id);

                    tbIdCredencial.Text = credencial.Id.ToString();
                    tbGuid.Text=credencial.Guid;
                    tbClave.Text = credencial.Clave;
                    tbScopes.Text = credencial.Scopes;

                    lvModulos.DataSource=oservice.moduloDAO.BuscarPorIdCredencial(credencial.Id).Tables[0];
                    lvModulos.DataBind();
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
            CredencialCliente nuevaCredencial = new CredencialCliente { Guid = guid, Clave=clave, Scopes= scopes };
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

                lvModulos.DataSource = oservice.moduloDAO.BuscarPorIdCredencial(idCredencial).Tables[0];
                lvModulos.DataBind();
            }
        }

        protected void lbtnEliminarModulo_Click(object sender, EventArgs e)
        {
            
        }

        protected void lbtnModificarModulo_Click(object sender, EventArgs e)
        {

        }
    }
}