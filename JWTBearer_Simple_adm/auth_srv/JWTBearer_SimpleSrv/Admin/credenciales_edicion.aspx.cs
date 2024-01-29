using JWTBearer_Models.Models;
using JWTBearer_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JWTBearer_SimpleServer.Admin
{
    public partial class credenciales_edicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                tbGuid.Text=Guid.NewGuid().ToString();
            }
        }

        protected void btnConfirmarAgregar_Click(object sender, EventArgs e)
        {
            string guid = tbGuid.Text;
            string clave = tbClave.Text;

            CredencialCliente nuevaCredencial = new CredencialCliente { Guid = guid, Clave=clave };
            JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager();
            oservice.AgregarCredencial(nuevaCredencial);
        }
    }
}