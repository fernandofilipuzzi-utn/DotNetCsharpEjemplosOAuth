﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace AppDemoCliente.services
{
    public class APIEjClient
    {
        public async Task<string> GetDato()
        {
            string respuesta="sin respuesta";

            string token = await GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                respuesta=await AccederAlServicioProtegido(token);
            }

            return respuesta;
        }

        private async Task<string> GetToken()
        {
            using (var client = new HttpClient())
            {
                var tokenEndpoint = "http://localhost:7777/identity/connect/token";
                var clientId = "client2";
                var clientSecret = "secret";
                var username = "usuario2";
                var password = "clave123";

                //grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1
                var tokenRequest = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", username },
                    { "password", password },
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "scope", "api1" },
                };

                var response =  client.PostAsync(tokenEndpoint, new FormUrlEncodedContent(tokenRequest)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var token = JObject.Parse(responseContent)["access_token"].ToString();
                    return token;
                }
                else
                {
                    Console.WriteLine($"Error al obtener el token: {response.StatusCode}");
                    return null;
                }
            }
        }

        private async Task<string> AccederAlServicioProtegido(string token)
        {
            string respuesta = "sin respuesta";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var servicioProtegidoEndpoint = "http://localhost:7778/api/Ej/MiServicioProtegido";

                var response = client.GetAsync(servicioProtegidoEndpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
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
