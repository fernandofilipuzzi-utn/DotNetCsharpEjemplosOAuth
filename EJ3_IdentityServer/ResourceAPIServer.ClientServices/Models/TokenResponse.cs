using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAPIServer.ClientServices.Models
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }

        public string error { get; set; }
        public string Message { get; set; }

        public static TokenResponse Parse(string json)
        {
            TokenResponse token = null;
            try
            {
                token =new TokenResponse
                {
                    access_token = JObject.Parse(json)["access_token"]?.ToString(),
                    token_type = JObject.Parse(json)["token_type"]?.ToString(),
                    expires_in = JObject.Parse(json)["expire_in"]?.ToString(),
                    error = JObject.Parse(json)["error"]?.ToString(),
                    Message = JObject.Parse(json)["Message"]?.ToString(),
                };
            } catch
            {
                token = new TokenResponse
                {
                    error = "error!",
                };
            }
            return token;
        }

        public bool HasExpired()
        {
            bool hasExpired = true;
            if (string.IsNullOrWhiteSpace(access_token)==false)
            {
                try
                {
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(access_token);
                    hasExpired = jwtSecurityToken.ValidTo <= DateTime.UtcNow;
                }
                catch
                {
                }
            }

            return hasExpired;
        }

        /// <summary>
        /// no indica si es porque es nulo o porque se venció
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            bool isValid=false;
            if (string.IsNullOrWhiteSpace(access_token)==false)
            {
                JwtSecurityToken jwtSecurityToken;
                try
                {
                    jwtSecurityToken = new JwtSecurityToken(access_token);
                    isValid = jwtSecurityToken.ValidTo > DateTime.UtcNow;
                }
                catch
                {
                }
            }

            return isValid;
        }   
    }
}
