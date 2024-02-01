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
    public partial class credenciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack==false)
            {
                actualizarListadoCredenciales();
            }
        }

        protected void lvCredenciales_ItemCreated(object sender, ListViewItemEventArgs e)
        {
        }

        protected void lvCredenciales_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            /*<asp:HyperLink ID="hlModificar" runat="server">MODIFICAR</asp:HyperLink>
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                HyperLink hlModificar= e.Item.FindControl("hlModificar") as HyperLink;
                int? Id = DataBinder.Eval(e.Item.DataItem, "id") as int?;
                hlModificar.NavigateUrl = $"credenciales_edicion.aspx?Id={Id}";
            }
            */
        }

        protected void lbtnEliminarCredencial_Click(object sender, EventArgs e)
        {
            LinkButton btnEliminarCredencial = sender as LinkButton;
            ListViewDataItem item = btnEliminarCredencial.NamingContainer as ListViewDataItem;
            Label lbIdCredencial = item.FindControl("lbIdCredencial") as Label;

            if (lbIdCredencial != null)
            {
                string idString = lbIdCredencial.Text.Trim();
                int idCredencial = Convert.ToInt32(idString);

                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
                oservice.credencialDAO.Eliminar(idCredencial); 
            }

            actualizarListadoCredenciales();
        }

        private void actualizarListadoCredenciales() 
        {
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);

            lvCredenciales.DataSource = oservice.credencialDAO.BuscarTodos().Tables[0];
            lvCredenciales.DataBind();
        }
    }
}