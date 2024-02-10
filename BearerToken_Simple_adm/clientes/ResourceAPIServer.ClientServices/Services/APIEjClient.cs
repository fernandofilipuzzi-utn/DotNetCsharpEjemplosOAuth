using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using ResourceAPIServer.ClientServices.Models;
using BearerToken.Utilities.Jwt;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace ResourceAPIServer.ClientServices.services
{
    public class APIEjClient
    {
        #region al athorizations server
        private readonly string tokenUrl = "http://localhost:7777";
        private readonly string pathToken = "/auth/token";
        private readonly string guid = "cbf25e40-b0da-4aa2-8a51-e2d701390ba1";
        private readonly string clave = "pFb2MKucltUts";

        public string tokenEndpoint
        {
            get
            {
                return $"{tokenUrl}{pathToken}";
            }
        }
        #endregion

        #region al resource service
        private readonly string apiUrl = "http://localhost:7778";
        private readonly string pathApi = "/api/Ejemplos/MiServicioProtegido";

        public string apiEndpoint
        {
            get
            {
                return $"{apiUrl}{pathApi}";
            }
        }
        #endregion

        public string GetDato()
        {
            string respuesta = "sin respuesta";

            TokenResponse token = GetToken();

            TokenJwtUtils utils = new TokenJwtUtils(token.access_token);
            if (utils.IsValid() == true)
            {
                respuesta = AccederAlServicioProtegido(token.access_token);
            }
            else
            {
                respuesta = token?.error;
            }
            return respuesta;
        }

        private TokenResponse GetToken()
        {
            TokenResponse token=null;
            using (var client = new HttpClient())
            {
                /*
                 en el caso de parametros en el head
                var tokenRequest = new Dictionary<string, string>
                {
                    { "guid", guid },
                    { "clave", clave }
                };
                */

                var jsonObject = new
                {
                    guid = guid,
                    clave = clave
                };

                string jsonString = System.Text.Json.JsonSerializer.Serialize(jsonObject);
                var content = new StringContent(jsonString, System.Text.Encoding.UTF8, "application/json");

                var response =  client.PostAsync(tokenEndpoint, content).Result;
                token = TokenResponse.Parse(response?.Content?.ReadAsStringAsync()?.Result);
            }
            return token;
        }

        private string AccederAlServicioProtegido(string token)
        {
            string respuesta = "sin respuesta";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
               
                var response = client.GetAsync(apiEndpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    respuesta=responseContent;
                }
                else
                {
                    respuesta=$"Error al acceder al servicio protegido: {response.StatusCode}";
                }
            }
            return respuesta;
        }
    }
}
