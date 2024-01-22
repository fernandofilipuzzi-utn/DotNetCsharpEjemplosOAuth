using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;
using AppDemoCliente.Properties;

namespace AppDemoCliente.services
{
    public class APIEjClientRestSharp
    {
        private readonly string tokenEndpoint = "http://localhost:7777";
        private readonly string clientId = "client_id";
        private readonly string clientSecret = "mi_secreto";
        private readonly string username = "user";
        private readonly string password = "123";

        public string GetDato()
        {
            string respuesta = "sin respuesta";

            string token =  ObtenerToken();
            if (!string.IsNullOrEmpty(token))
            {
                respuesta = AccederAlServicioProtegido(token);
            }

            return respuesta;
        }

        private  string ObtenerToken()
        {
            var client = new RestClient(tokenEndpoint);
            var request = new RestRequest(resource:"api/token",method:Method.Post);

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);

            var response = client.ExecuteAsync(request).Result;
            if (response.IsSuccessful)
            {
                var token = JObject.Parse(response.Content)["access_token"].ToString();
                return token;
            }
            else
            {
                Console.WriteLine($"Error al obtener el token: {response.StatusCode}");
                return null;
            }
        }

        private string AccederAlServicioProtegido(string token)
        {
            var client = new RestClient("http://localhost:7778");
            var request = new RestRequest(resource: "api/Ej/MiServicioProtegido", method: Method.Get);

            request.AddHeader("Authorization", $"Bearer {token}");

            var response =  client.ExecuteAsync(request).Result;
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                return $"Error al acceder al servicio protegido: {response.StatusCode}";
            }
        }
    }

}
