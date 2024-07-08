using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace signning.client
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!Request.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
                {
                    RedirectUri = Request.Url.AbsoluteUri
                }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            */

            var claimsIdentity = User.Identity as ClaimsIdentity;


            //lb1.Text = claimsIdentity?.FindFirst(c => c.Type == claimsIdentity.NameClaimType)?.Value;
            //lb2.Text = claimsIdentity?.FindFirst(c => c.Type == ClaimTypes.Email)?.Value;
            //lb3.Text = claimsIdentity?.FindFirst(c => c.Type == "picture")?.Value;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (User.Identity.IsAuthenticated == false)
            {
                HttpContext.Current.GetOwinContext().Authentication.Challenge(
                    new AuthenticationProperties { RedirectUri = "/" },
                    OpenIdConnectAuthenticationDefaults.AuthenticationType);


            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //HttpContext.Current.GetOwinContext().Authentication.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            ////HttpContext.Current.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);


            //Session.Abandon();
            //FormsAuthentication.SignOut();

            ////IOwinContext context = HttpContext.Current.GetOwinContext();
            ////IAuthenticationManager authenticationManager = context.Authentication;
            ////authenticationManager.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
            ///
            //HttpContext.Current.GetOwinContext().Authentication.SignOut(
            //new AuthenticationProperties { RedirectUri = "/" },
            //OpenIdConnectAuthenticationDefaults.AuthenticationType,
            //CookieAuthenticationDefaults.AuthenticationType);

            HttpContext.Current.GetOwinContext().Authentication.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
         Response.Redirect("/");
        }
    }
}