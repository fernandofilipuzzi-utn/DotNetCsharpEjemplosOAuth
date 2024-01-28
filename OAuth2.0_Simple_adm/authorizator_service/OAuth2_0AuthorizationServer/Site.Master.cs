using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OAuth2_0AuthorizationServer
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UsuarioSettings"];

            if (cookie == null)
            {
                Response.Redirect("admin/login.aspx");
            }
            else
            {
                string usuario = cookie["Usuario"];
                string expiracion = cookie["Expiracion"];
                if (string.IsNullOrEmpty(expiracion) == false)
                {
                    DateTime expire = DateTime.Parse(expiracion);
                    if (DateTime.Now > expire)
                        Response.Redirect("login");
                }
            }
        }

        protected void hlkCerrar_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UsuarioSettings"];

            if (cookie != null)
            {
                cookie["Expiracion"] = DateTime.Now.ToString();
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("login");
        }

        public void ShowMessage(string titulo, string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"mostrarModal('{ mensaje}');", true);
        }
    }
}