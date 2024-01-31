using Microsoft.IdentityModel.Tokens;
using ResourceAPIServer.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace ResourceAPIServer.AuthBearerTokenUtils
{
    public class ValidatorBearerToken
    {
        public bool Validar(string token)
        {
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
                ClockSkew = TimeSpan.Zero // Sin desplazamiento de tiempo permitido
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (!jwtToken.Payload.TryGetValue("guid", out var guid)) //|| guid.ToString() != "expectedGuid")
                {

                    return false;
                }
                else
                {
                    //context.OwinContext.Request.User = principal;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}