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
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

using Newtonsoft.Json;
using ResourceAPIServer.ClientServices.Models;
//using IdentityModel.Client; este no

namespace ResourceAPIServer.ClientServices.services
{
    public class APIEjClientRestSharp
    {
        #region al athorizations server
        private readonly string tokenUrl = "http://localhost:7777";
        private readonly string pathToken = "/identity/connect/token";
        private readonly string clientId = "client2";
        private readonly string clientSecret = "secret";
        private readonly string username = "usuario2";
        private readonly string password = "clave123";
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
        private readonly string pathApi = "/api/Ej/MiServicioProtegido";
        private readonly string scope = "api1";//separados por espacio
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

            TokenResponse token = ObtenerToken();// "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDM2NzgyLCJuYmYiOjE3MDYwMzU1ODIsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDM1NTgyLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.lCiZ62Dn-0gM7pmYLaNHH6j6UxZyM1QaCbCIIh_1L2YGRgYeVZauFbm2RYt_ZeIG73975bwbvkoriKwXZerWXnsXEpKXEARIrgrkiezsxLjUQk1rBusyBgSaCpO2wO3xNtcIg0e9WrGJ6E2FxNNORv3pQx3pR4dyc_iTpyivNV5zUbVIKJBLNMKYc474CR-PgP-IoPUWX18DYCizUfozbDpNWDj4BtenQdxI2BNEln0OHiumQamB4S87P3kKg-dIn8KFnt_zQAENDQnk-7pVPzmAsj2EAp4SJeeOgbjfu8Ur3YpHbl72XLkyF36Wz2TRrql3SWAFYD9PLiDl1pGQbA";
            if (token?.IsValid()==true)
            { 
                respuesta = AccederAlServicioProtegido(token.access_token);
            }
            else
            {
                respuesta = token?.error;
            }
            return respuesta;
        }
      
        private TokenResponse ObtenerToken()
        {
            var token = new TokenResponse();
            //
            var request = new RestRequest(resource: pathToken, method: Method.Post) ;
            var client = new RestClient(tokenUrl);
            //
            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", clientId);
            request.AddParameter("client_secret", clientSecret);
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("scope", scope);
            //
            var response = client.ExecuteAsync(request).Result;
            token = TokenResponse.Parse(response.Content);
            return token;
        }

        private string AccederAlServicioProtegido(string authBearer)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(authBearer, "Bearer");
            var options = new RestClientOptions(apiUrl)
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);

            var request = new RestRequest(pathApi, Method.Get);
            var response = client.ExecuteAsync(request).Result;

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

