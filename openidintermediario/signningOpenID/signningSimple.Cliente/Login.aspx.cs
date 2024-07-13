using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signningSimple.Cliente
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string usr=tbUsuario.Text.Trim();
            string pwd=tbClave.Text.Trim();
            if (string.IsNullOrEmpty(usr) || string.IsNullOrEmpty(pwd))
            {
                pnlMensaje.Enabled = false;
                lbDescripcion.Text = "Error en el login";
                return;
            }

            if (usr == "admin" && pwd == "123")
            {
                HttpCookie cookie = new HttpCookie("UsuarioSettings");
                cookie["usuario"] = usr;
                cookie.Expires = DateTime.Now.AddMinutes(3);
                HttpContext.Current.Response.Cookies.Add(cookie);

                Response.Redirect("Default");
            }
            else
            {
                pnlMensaje.Enabled = false;
                lbDescripcion.Text = "Error en el login";
            }
        }

        protected void btnOtros_Click(object sender, EventArgs e)
        {
            string idSistema = ConfigurationManager.AppSettings["Id_Sistema"];
            string idModulo = ConfigurationManager.AppSettings["Id_Modulo"]; 
            string idMunicipio = ConfigurationManager.AppSettings["Id_Municipio"];
           
            Response.Redirect($"https://localhost:44344/AuthorizeClient?Id_Sistema={idSistema}&Id_Modulo={idModulo}$Id_Municipio={idMunicipio}");
        }

    }
}