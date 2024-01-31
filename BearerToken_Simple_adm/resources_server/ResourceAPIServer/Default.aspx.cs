using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResourceAPIServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnModo1_Click(object sender, EventArgs e)
        {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyGCsvt-RW72c0-w50u0RR2BWsm2fj4w";
            Response.Redirect($"/modo_autorizacion_1/FormularioPrueba.aspx?embedToken={token}");
        }

        protected void btnModo2_Click(object sender, EventArgs e)
        {
            //ver ruta en web.config
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzU1MDc3fQ.UnVh7TZ2Hdc3tewunAgFvFC9pEEI3RNzlbAedDxhrUM";
            Response.Cookies.Add(new HttpCookie("jwtToken", token));
            Response.Headers.Add("Authorization",$"Bearer {token}");
            Response.Redirect($"/modo_autorizacion_2/FormularioPrueba.aspx");
        }
    }
}