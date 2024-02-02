using BearerToken.Utilities.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResourceAPIServer.web_tokenizada_modo_token_url
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["embedToken"]) == false)
            {
                ///
                ///ejemplo
                ///url: https://localhost:44386/Default?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyGCsvt-RW72c0-w50u0RR2BWsm2fj4w

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