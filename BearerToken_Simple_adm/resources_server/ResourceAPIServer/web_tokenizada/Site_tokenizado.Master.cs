using BearerToken.Utilities.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResourceAPIServer.web_tokenizada
{
    public partial class Site_tokenizado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["embedToken"]) == false)
            {
                string token = Request["embedToken"].Trim();

                BearerTokenAuthenticator validator = new BearerTokenAuthenticator(token, "secret");
                if (validator.ValidarToken() == false)
                {
                    Response.Redirect("/Error");
                }
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
    }
}