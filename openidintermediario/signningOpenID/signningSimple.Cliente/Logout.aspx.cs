using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signningSimple.Cliente
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UsuarioSettings"] != null)
            {
                HttpCookie myCookie = new HttpCookie("UsuarioSettings");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);

                string idSistema = ConfigurationManager.AppSettings["Id_Sistema"];
                string idModulo = ConfigurationManager.AppSettings["Id_Modulo"];
                string idMunicipio = ConfigurationManager.AppSettings["Id_Municipio"];

                Response.Redirect($"https://localhost:44344/AuthorizeClient?Id_Sistema={idSistema}&Id_Modulo={idModulo}&Id_Municipio={idMunicipio}&action=unsinged");
            }
        }
    }
}