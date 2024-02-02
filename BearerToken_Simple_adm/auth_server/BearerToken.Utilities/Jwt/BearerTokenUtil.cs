using BearerToken.Utilities.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken.Utilities.Jwt
{
    public class BearerTokenUtil
    {
        public string Token { get; set; }
        public string ClaveFirma { get; set; }
        public ClaimsPrincipal Claims { get; set; }

        JwtSecurityTokenHandler tokenHandler;
        TokenValidationParameters tokenValidationParameters;

        public BearerTokenUtil(string token, string claveFirma)
        {
            Token = token;
            ClaveFirma = claveFirma;
            //
            string secretKey = ClaveFirma.Sha256();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Sin desplazamiento de tiempo permitido
            };
           
        }

        public bool ValidarToken()
        {
            try
            {
                tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(Token, tokenValidationParameters, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken.Payload.TryGetValue("guid", out var guid) == true)
                {
                    Claims = principal;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return true;
            }
            return false;
        }

        public bool TryGetClaimValue(string parametro, out string valorClaim)
        {
            var claim = Claims?.FindFirst(parametro);

            if (claim != null )
            {
                valorClaim = claim.Value;
                return true;
            }
            valorClaim = null;
            return false;
        }
    }
}
