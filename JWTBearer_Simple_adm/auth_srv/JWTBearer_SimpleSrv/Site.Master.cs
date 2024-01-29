using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer
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
                if (string.IsNullOrEmpty(expiracion) == true)
                {
                    DateTime expire = DateTime.Parse(expiracion);
                    if (DateTime.Now > expire)
                        Response.Redirect("admin/login.aspx");
                }
            }
        }

        protected void hlkCerrar_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UsuarioSettings"];

            if (cookie != null)
            {
                Request.Cookies.Clear();
                Response.Cookies.Remove("UsuarioSettings");
            }
            Response.Redirect("admin/login.aspx");
        }

        public void ShowMessage(string titulo, string mensaje)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showModal", $"mostrarModal('{ mensaje}');", true);
        }
    }
}