using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BearerToken_SimpleServer_adm
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UsuarioSettings"];

            if (cookie == null)
            {
                Response.Redirect("/Admin/login.aspx");
            }
            else
            {
                string usuario = cookie["usuario"];
                if (DateTime.Now < cookie.Expires)
                {
                    Response.Redirect("/Admin/login.aspx");
                }
                else
                {
                    lbUsuarioNombre.Text = usuario;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtnCerrar_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UsuarioSettings"];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("/Admin/login.aspx");
        }

        public void ShowMessage(string titulo, string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"mostrarModal('{ mensaje}');", true);
        }
    }
}