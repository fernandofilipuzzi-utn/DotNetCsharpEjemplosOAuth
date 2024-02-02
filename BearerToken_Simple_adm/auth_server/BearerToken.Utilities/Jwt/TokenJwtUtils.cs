using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearerToken.Utilities.Jwt
{
    public class TokenJwtUtils
    {
        string token;
        JwtSecurityToken jwtSecurityToken;

        public TokenJwtUtils(string token)
        {
            this.token = token;
            jwtSecurityToken = new JwtSecurityToken(token);
        }

        public bool GetValorClaim(string parametro, out string valor)
        {
            valor = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == parametro)?.Value;
            return valor!=null;
        }

        public bool HasExpired()
        {
            bool hasExpired = true;
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                try
                {
                    hasExpired = jwtSecurityToken.ValidTo <= DateTime.UtcNow;
                }
                catch
                {
                }
            }
            return hasExpired;
        }

        public bool IsValid()
        {
            bool isValid = false;
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                try
                {
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
