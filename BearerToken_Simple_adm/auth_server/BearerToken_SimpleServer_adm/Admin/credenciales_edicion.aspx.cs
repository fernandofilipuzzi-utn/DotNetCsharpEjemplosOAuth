using BearerToken_Models.Models;
using BearerToken_Services.Services;
using BearerToken_SimpleServer_adm.Utils;
using System;
using System.Collections.Generic;
using System.Data;
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
                    tbDescripcionCredencial.Text = credencial.Descripcion;
                    tbScopesCredencial.Text = credencial.Scopes;

                    actualizarVistaModulos(credencial.Id);

                    chkHabilitadoCredencial.Checked = credencial.Habilitado;

                    btnConfirmarOPCredencial.Text = "Modificar Credencial";
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
            //
            string guidCredencial = tbGuidCredencial.Text.Trim();
            string claveCredencial = tbClaveCredencial.Text.Trim();
            string descripcionCredencial = tbDescripcionCredencial.Text.Trim().ToLower();
            string scopesCredencial = tbScopesCredencial.Text.Trim().ToLower();
            bool habilitadoCredencial = chkHabilitadoCredencial.Checked;
            //
            CredencialClienteAPI credencial = new CredencialClienteAPI
            {
                Guid = guidCredencial,
                Clave = claveCredencial,
                Descripcion = descripcionCredencial,
                Scopes = scopesCredencial,
                Habilitado=habilitadoCredencial
            };
            //
            if (string.IsNullOrEmpty(tbIdCredencial.Text) == false)
            {
                int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
                credencial.Id = idCredencial;
                oservice.credencialDAO.Actualizar(credencial);
            }
            else 
            {
                oservice.credencialDAO.Agregar(credencial);
            }

            Response.Redirect("/Admin/credenciales.aspx");
        }

        #region amb modulos


        protected void lvModulos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
        }

        protected void lbtnEdEliminarModulo_Click(object sender, EventArgs e)
        {
            #region captura de valores del formulario
            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
            //
            LinkButton btnEdEliminarModulo = sender as LinkButton;
            //
            ListViewDataItem item = btnEdEliminarModulo?.NamingContainer as ListViewDataItem;
            TextBox tbEdIdModulo = item?.FindControl("tbEdIdModulo") as TextBox;
            //
            int idModulo = Convert.ToInt32(tbEdIdModulo.Text.Trim());
            #endregion

            #region persistencia
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
            oservice.moduloDAO.Eliminar(idModulo);
            #endregion

            #region actualizacion vista
            actualizarVistaModulos(idCredencial);
            #endregion
        }

        protected void lbtnEdModificarModulo_Click(object sender, EventArgs e)
        {
            #region captura de valores del formulario
            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
            //
            LinkButton btn = sender as LinkButton;
            //
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            TextBox tbEdIdModulo = item.FindControl("tbEdIdModulo") as TextBox;
            TextBox tbEdDescripcionModulo = item.FindControl("tbEdDescripcionModulo") as TextBox;
            TextBox tbEdUrlModulo = item.FindControl("tbEdUrlModulo") as TextBox;
            //
            int idModulo = Convert.ToInt32(tbEdIdModulo.Text.Trim());
            string descripcionModulo = tbEdDescripcionModulo.Text.Trim().ToUpper();
            string urlModulo = tbEdUrlModulo.Text.Trim();
            #endregion
            
            #region persistencia
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oService = new BearerToken_ServicesManager(pathDb);
            oService.moduloDAO.Actualizar(new Modulo 
            { 
                Id=idModulo,
                Descripcion=descripcionModulo, 
                Url=urlModulo
            });
            #endregion
                       
            actualizarVistaModulos(idCredencial);
        }

        protected void lbtnInsertNuevoModulo_Click(object sender, EventArgs e)
        {
            #region captura de valores del formulario
            int idCredencial = Convert.ToInt32(tbIdCredencial.Text);
            //
            TextBox tbInsertDescripcionModulo = lvModulos.InsertItem.FindControl("tbInsertDescripcionModulo") as TextBox;
            TextBox tbInsertUrlModulo = lvModulos.InsertItem.FindControl("tbInsertUrlModulo") as TextBox;
            #endregion

            if (tbInsertDescripcionModulo != null && tbInsertUrlModulo != null)
            {
                string descripcion = tbInsertDescripcionModulo.Text;
                string url = tbInsertUrlModulo.Text;

                #region persistencia
                string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
                BearerToken_ServicesManager oservice = new BearerToken_ServicesManager(pathDb);
                Modulo nuevo = new Modulo { Descripcion = descripcion, Url = url };
                oservice.moduloDAO.Agregar(nuevo, idCredencial);
                #endregion

                actualizarVistaModulos(idCredencial);
            }
        }

        private void actualizarVistaModulos(int idCredencial)
        {
            string pathDb = Server.MapPath("~/db/db_auth_jwt_bearer.db");
            BearerToken_ServicesManager oService = new BearerToken_ServicesManager(pathDb);
            lvModulos.DataSource = oService.moduloDAO.BuscarPorIdCredencial(idCredencial).Tables[0];
            lvModulos.DataBind();
        }

        #endregion


        
    }
}