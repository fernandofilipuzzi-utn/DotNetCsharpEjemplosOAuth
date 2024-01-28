using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //credenciales
            string guid = txtUsername.Text;
            string password = txtPassword.Text;

           // if (username == "usuario" && password == "contraseña")
           // {
                // Si las credenciales son válidas, generar un token JWT
                // ...

                // Obtener la URL de retorno (returnUrl) si está presente en la solicitud
                string returnUrl = Request.QueryString["returnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl); 
                    return;
                }
                else
                {
                    Response.Redirect("http://localhost:7777/resource-api/resource-page.aspx");
                    return;
                }
         //   }
        }
    }
}