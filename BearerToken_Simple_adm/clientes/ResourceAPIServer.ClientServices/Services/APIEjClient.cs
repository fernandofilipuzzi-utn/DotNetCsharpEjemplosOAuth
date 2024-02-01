﻿using System;
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

namespace ResourceAPIServer.ClientServices.services
{
    public class APIEjClient
    {
        #region al athorizations server
        private readonly string tokenUrl = "http://localhost:7777";
        private readonly string pathToken = "/auth/token";
        private readonly string guid = "cbf25e40-b0da-4aa2-8a51-e2d701390ba1";
        private readonly string frase = "pFb2MKucltUts";

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
        private readonly string pathApi = "/api/MiServicioProtegido";

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
                var tokenRequest = new Dictionary<string, string>
                {
                    { "guid", guid },
                    { "frase", frase }
                };

                var response =  client.PostAsync(tokenEndpoint, new FormUrlEncodedContent(tokenRequest)).Result;
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
