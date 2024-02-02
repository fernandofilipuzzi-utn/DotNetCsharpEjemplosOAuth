using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResourceAPIServer.modo_autorizacion_2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.Cookies["jwtToken"]?.Value;

            if (string.IsNullOrEmpty(token))
            {
                //
                Response.Redirect("/Error");
            }
            else
            {
                //
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            }
        }
    }
}