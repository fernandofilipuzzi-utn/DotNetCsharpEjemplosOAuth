using Microsoft.IdentityModel.Tokens;
using ResourceAPIServer.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ResourceAPIServer
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request["embedToken"]) == false)
            {
                //ejemplo
                //https://localhost:44386/Default?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA2NzI4NjgyfQ.N8Vd7jHIqvcaNU2cICz6PorZmu8Wr1k5SEh3D4EznWk
                
                string token = Request["embedToken"].Trim();

                #region validacion token
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

                        Response.Redirect("Error");
                    }
                    else
                    {
                        //context.OwinContext.Request.User = principal;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error");
                }
                #endregion
            }
            else 
            {
                Response.Redirect("Error");
            }
        }
    }
}