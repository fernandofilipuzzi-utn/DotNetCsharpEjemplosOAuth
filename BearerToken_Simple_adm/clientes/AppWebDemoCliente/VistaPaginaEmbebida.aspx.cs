using ResourceAPIServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebDemoCliente
{
    public partial class VistaPaginaEmbebida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cuitUsuario = "201231222";
                //
                MiAutenticador miAutenticador = new MiAutenticador();
                cuitUsuario = "201231222";
                string token = miAutenticador.GetToken(cuitUsuario);
                //
                if (string.IsNullOrEmpty(token) == false)
                {
                    string url = $"http://localhost:7778/web_tokenizada/PaginaTokenizada.aspx?embedToken={token}";
                    //Response.Redirect(url);
                    iframeControl.Attributes["src"] = url;
                }
                else
                {
                }
            }
        }
    }
}