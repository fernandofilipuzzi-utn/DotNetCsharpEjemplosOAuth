using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signningSimple.Cliente
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            HttpCookie cookie = null;
           string token = Request["token"];

            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }
            else
            {

                cookie = new HttpCookie("UsuarioSettings");

                var myObject = new
                {
                    usuario="fernando"
                };

                string jsonString = JsonConvert.SerializeObject(myObject);
                cookie.Value = jsonString;

                Response.Cookies.Add(cookie);

            }


            cookie = Request.Cookies["UsuarioSettings"];
            if (cookie != null)
            {
                string usuario = cookie["usuario"];
                Response.Redirect("~/Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}