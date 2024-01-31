using BearerToken_Models.Models;
using BearerToken_Services.Services;
using BearerToken_SimpleServer_adm.Utils;
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
                    tbGuidCredencial.Text = credencial.Guid;
                    tbClaveCredencial.Text = credencial.Clave;
                    tbScopesCredencial.Text = credencial.Scopes;

                    actualizarVistaModulos(credencial.Id);
                }
                else
                {
                    tbGuidCredencial.Text = Guid.NewGuid().ToString();
                    tbClaveCredencial.Text = StringUtils.GenerarClave(13);
                }
            }
        }

        protected void btnConfirmarOPCredencial_Click(object sender, EventArgs e)
        {
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);

            
            string guidCredencial = tbGuidCredencial.Text;
            string claveCredencial = tbClaveCredencial.Text;
            string scopesCredencial = tbScopesCredencial.Text;

            if (string.IsNullOrEmpty(tbIdCredencial.Text) == false)
            {
                int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
                CredencialClienteAPI credencial = new CredencialClienteAPI 
                {   
                    Id= idCredencial,
                    Guid = guidCredencial, 
                    Clave = claveCredencial, 
                    Scopes = scopesCredencial
                };
                oservice.credencialDAO.Actualizar(credencial);
            }
            else 
            {
                CredencialClienteAPI nuevaCredencial = new CredencialClienteAPI
                {
                    Guid = guidCredencial,
                    Clave = claveCredencial,
                    Scopes = scopesCredencial
                };
                oservice.credencialDAO.Agregar(nuevaCredencial);
            }

            Response.Redirect("/Admin/credenciales.aspx");
        }

        protected void lvModulos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
        }

        protected void lbtnInsertNuevoModulo_Click(object sender, EventArgs e)
        {
            TextBox tbInsertIdModulo = lvModulos.InsertItem.FindControl("tbInsertIdModulo") as TextBox;
            TextBox tbInsertDescripcionModulo = lvModulos.InsertItem.FindControl("tbInsertDescripcionModulo") as TextBox;
            TextBox tbInsertUrlModulo = lvModulos.InsertItem.FindControl("tbInsertUrlModulo") as TextBox;

            int idCredencial=Convert.ToInt32(tbIdCredencial.Text);

            if (tbInsertDescripcionModulo != null && tbInsertUrlModulo != null)
            {
                string descripcion = tbInsertDescripcionModulo.Text;
                string url = tbInsertUrlModulo.Text;

                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
                Modulo nuevo = new Modulo { Descripcion = descripcion, Url = url };
                oservice.moduloDAO.Agregar(nuevo, idCredencial);

                actualizarVistaModulos(idCredencial);
            }
        }

        protected void lbtnEdEliminarModulo_Click(object sender, EventArgs e)
        {
            // Obtener el ID del módulo desde el CommandArgument del botón
            LinkButton btn = (LinkButton)(sender);
            int idModulo = Convert.ToInt32(btn.CommandArgument);

            // Obtener otros campos del ItemTemplate
            ListViewDataItem item = (ListViewDataItem)btn.NamingContainer;
            TextBox tbEdIdModulo = (TextBox)item.FindControl("tbEdIdModulo");
            TextBox tbEdDescripcionModulo = (TextBox)item.FindControl("tbEdDescripcionModulo");
            TextBox tbEdUrlModulo = (TextBox)item.FindControl("tbEdUrlModulo");

            //
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
            oservice.moduloDAO.Eliminar(idModulo);

            // Actualizar la vista después de eliminar el módulo
            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
            actualizarVistaModulos(idCredencial);
        }

        protected void lbtnEdModificarModulo_Click(object sender, EventArgs e)
        {
            #region controles
            LinkButton btn = (LinkButton)(sender);
            //
            ListViewDataItem item = (ListViewDataItem)btn.NamingContainer;
            TextBox tbEdIdModulo = (TextBox)item.FindControl("tbEdIdModulo");
            TextBox tbEdDescripcionModulo = (TextBox)item.FindControl("tbEdDescripcionModulo");
            TextBox tbEdUrlModulo = (TextBox)item.FindControl("tbEdUrlModulo");
            #endregion
            //
            #region parsing
            int idModulo = Convert.ToInt32(tbEdIdModulo.Text.Trim());
            string descripcionModulo = tbEdDescripcionModulo.Text.Trim();
            string urlModulo = tbEdUrlModulo.Text.Trim();
            #endregion
            //
            #region op sobre el registro
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
            oservice.moduloDAO.Actualizar(new Modulo { Id=idModulo,Descripcion=descripcionModulo, Url=urlModulo  });
            #endregion
            //
            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
            actualizarVistaModulos(idCredencial);
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