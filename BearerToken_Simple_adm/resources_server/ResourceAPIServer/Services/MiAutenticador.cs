using BearerToken_SimpleServer_adm.Models;
using Newtonsoft.Json;
using ResourceAPIServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace ResourceAPIServer.Services
{
    //servicio
    public class MiAutenticador
    {
        //auth
        private readonly string tokenUrl = "http://localhost:7777";
        private readonly string pathToken = "/auth/token";
        private readonly string guid = "cbf25e40-b0da-4aa2-8a51-e2d701390ba1";
        private readonly string frase = "pFb2MKucltUts";
        //modulos
        private readonly string apiUrl = "http://localhost:7778";
        private readonly string pathApi = "/api/MiServicioProtegido";

        public string GetToken(string cuit)
        {
            try
            {
                string token = null;
                using (var client = new HttpClient())
                {
                    /*
                    var tokenRequest = new
                    {
                        guid = guid,
                        frase = frase,
                        cuit = cuit
                    };
                    var response = client.PostAsJsonAsync($"{tokenUrl}{pathToken}", tokenRequest).Result;
                    response.EnsureSuccessStatusCode();
                   
                    var tokenRequest = new Dictionary<string, string>
                    {
                        { "guid", guid },
                        { "frase", frase }
                    };
                    
                    var response = client.PostAsync($"{tokenUrl}{pathToken}", new FormUrlEncodedContent(tokenRequest)).Result;

                    client.DefaultRequestHeaders.Add("guid", "valor_del_guid");
                    client.DefaultRequestHeaders.Add("frase", "valor_de_la_frase");

                     */
                    RequestToken request = new RequestToken {GUID= "cbf25e40-b0da-4aa2-8a51-e2d701390ba1",
                                                            Clave= "pFb2MKucltUts"
                    };
                    var jsonRequest = JsonConvert.SerializeObject(request);
                    var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    var response = client.PostAsync($"{tokenUrl}{pathToken}", content).Result;

                    var json = response.Content.ReadAsStringAsync().Result;
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(json);
                    token = tokenResponse.access_token;
                }
                return token;
            } catch(Exception ex)
            { 
            }
            return "";
        }
    }
}