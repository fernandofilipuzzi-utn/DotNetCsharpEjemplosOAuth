using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer.Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["UsuarioSettings"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(3);
                HttpContext.Current.Response.Cookies.Add(cookie);

                Response.Redirect("../Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text;
            string clave = tbClave.Text;

            if (usuario == "admin" && clave == "admin")
            {
                #region cookie
                HttpCookie cookie = new HttpCookie("UsuarioSettings");
                cookie["usuario"]=usuario;
                cookie.Expires = DateTime.Now.AddMinutes(3);
                HttpContext.Current.Response.Cookies.Add(cookie);
                #endregion

                Response.Redirect("/Default", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lbError.Text = "error";
                lbError.Visible = true;
            }
        }
    }
}