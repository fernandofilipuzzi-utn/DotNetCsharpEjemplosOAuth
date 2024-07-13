using DTO_lib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signningSimple
{
    public partial class Authorize1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) return;

         
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;


                if (claimsIdentity != null)
                {
                    string nombre = claimsIdentity?.FindFirst(c => c.Type == claimsIdentity.NameClaimType)?.Value;
                    string email = claimsIdentity?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;


                    HttpCookie cookie = Request.Cookies["authorize_session"];
                    if (cookie != null)
                    {
                        dynamic jsonObject = JsonConvert.DeserializeObject(cookie.Value);

                        string urlRegister = jsonObject.urlRedirectRegistre;

                        string token = "";
                        #region registro
                        DTO_Ciudadano datos = new DTO_Ciudadano
                        {
                            Email = email,
                        };
                        token = "";// getToken(urlRegister, datos).Result;
                        #endregion

                        string urlRedirect = $"jsonObject.urlRedirect?token={token}";
                        Response.Redirect(urlRedirect);
                    }
                }
            }
        }
   
        async Task<string>  getToken(string urlRegister, DTO_Ciudadano datos)
        {
            string token="";
            using (HttpClient client = new HttpClient())
            {
               

                HttpContent content = new StringContent(JsonConvert.SerializeObject(datos), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(urlRegister, content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    DTO_Respuesta respuesta = JsonConvert.DeserializeObject<DTO_Respuesta>(jsonString);

                    token = respuesta.Datos.ToString();
                }
            }
            return token;
        }
    }
}