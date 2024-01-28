using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace ResourceAPIServer.Utils
{
    public class JwtValidator
    {
        private readonly string _secretKey;

        public JwtValidator(string secretKey)
        {
            _secretKey = secretKey;
        }

        public ClaimsPrincipal ValidateToken(string tokenString, string expectedGuid, string expectedFrase)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            string secretKey = "secret".Sha256();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero 
            };

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(tokenString, tokenValidationParameters, out validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken.Payload.TryGetValue("guid", out object guid) && jwtToken.Payload.TryGetValue("frase", out object frase))
                {
                    if (guid.ToString() == expectedGuid && frase.ToString() == expectedFrase)
                    {
                        return principal;
                    }
                }

                throw new SecurityTokenException("Token inválido: Parámetros 'guid' o 'frase' incorrectos");
            }
            catch (SecurityTokenException ex)
            {
                throw new SecurityTokenException($"Token inválido: {ex.Message}");
            }
        }
    }
}