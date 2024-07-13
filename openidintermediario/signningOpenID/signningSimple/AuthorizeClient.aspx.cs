using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signningSimple
{
    public partial class AuthorizeClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

            string idSistema = Request["Id_Sistema"];
            string idModulo = Request["Id_Modulo"];
            string idMunicipio = Request["Id_Municipio"];
            string urlRedirect = "https://localhost:44301";
            string urlRedirectRegistre = "https://localhost:44344/api/Registre/Registre";

            if (string.IsNullOrWhiteSpace(idSistema) || string.IsNullOrWhiteSpace(idModulo) || string.IsNullOrWhiteSpace(idMunicipio))
            {
                return;
            }

            HttpCookie cookie = Request.Cookies["authorize_session"];
            if (cookie != null)
            {
                Response.Redirect(urlRedirect);
            }
            else
            {
                cookie = new HttpCookie("authorize_session");
                cookie.Expires = DateTime.Now.AddDays(1);

                var myObject = new
                {
                    IdSistema = 1,
                    IdModulo = 1,
                    IdMunicipio = 1,
                    urlRedirect = urlRedirect,
                    urlRedirectRegistre = urlRedirectRegistre
                };

                string jsonString = JsonConvert.SerializeObject(myObject);
                cookie.Value= jsonString;
                Response.Cookies.Add(cookie);
            }
        }

        protected void btnGoogle_Click(object sender, EventArgs e)
        {
            var provider = "Google";
            var properties = new AuthenticationProperties { RedirectUri = "/Authorize" };
            Context.GetOwinContext().Authentication.Challenge(properties, provider);
            Response.StatusCode = 401;
            Response.End();
          
        }
    }
}