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
using System.Web.Mvc;

namespace signningSimple.Controllers
{
  //  [RoutePrefix("Authorize")]
    public class AuthorizeController : Controller
    {
       
        public async Task<ActionResult> Index()
        {
            if (Request.IsAuthenticated)
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity != null)
                {
                    string nombre = claimsIdentity?.FindFirst(c => c.Type == claimsIdentity.NameClaimType)?.Value;
                    string email = claimsIdentity?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;

                    HttpCookie cookie = Request.Cookies["authorize_session"];
                    if (cookie != null)
                    {
                        dynamic jsonObject = JsonConvert.DeserializeObject(cookie.Value);

                        string urlRegister = jsonObject.urlRedirectRegistre;

                        DTO_Ciudadano datos = new DTO_Ciudadano
                        {
                            Email = email,
                        };

                        string token = await GetTokenAsync(urlRegister, datos);

                        string url = $"{jsonObject.urlRedirect}?token={token}";
                        return Redirect(url);
                    }
                }
            }
            string urlRedirect = "https://localhost:44344/";
            return Redirect(urlRedirect);
        }


        private async Task<string> GetTokenAsync(string urlRegister, DTO_Ciudadano datos)
        {
            string token = "";
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
