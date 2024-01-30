using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

namespace BearerToken_SimpleServer.Utils
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private byte[] _secret;
        private readonly string _guid;

        public CustomJwtFormat(string guid, string secret)
        {
            _guid = guid;
            _secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(_secret);

            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            return new JwtSecurityTokenHandler().WriteToken(
                        new JwtSecurityToken(_guid, "Any", data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials)
            );
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}