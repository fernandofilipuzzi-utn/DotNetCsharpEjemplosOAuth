using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebDemoCliente
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModo1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/VistaPaginaEmbebida.aspx");
        }
        protected void btnModo2_Click(object sender, EventArgs e)
        {
            //ver ruta en web.config
            /*en pruebas
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzU1MDc3fQ.UnVh7TZ2Hdc3tewunAgFvFC9pEEI3RNzlbAedDxhrUM";
            Response.Cookies.Add(new HttpCookie("jwtToken", token));
            Response.Headers.Add("Authorization", $"Bearer {token}");
            Response.Redirect($"/modo_autorizacion_2/FormularioPrueba.aspx");
            */
        }
    }
}