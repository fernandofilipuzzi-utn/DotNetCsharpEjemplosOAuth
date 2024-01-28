using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using IdentityServer3.Core.Services;
using OAuth2_0AuthorizationServer.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using OAuth2_0AuthorizationServer.Configuration;
using System.Text;
using Microsoft.Owin.Security.Jwt;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.Owin.Security.DataHandler.Encoder;

[assembly: OwinStartup(typeof(OAuth2_0AuthorizationServer.Startup))]
namespace OAuth2_0AuthorizationServer
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            var issuer = "http://localhost:56228/";
            var secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw";
            var guid = "d1050b9c-4805-4ea3-8f66-6a601490010a";
          
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new CustomOAuthProvider(guid, secret),
                AccessTokenFormat = new CustomJwtFormat(issuer, secret)
            });
        }
    }
}