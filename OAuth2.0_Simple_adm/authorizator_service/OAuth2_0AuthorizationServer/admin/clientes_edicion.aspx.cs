using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OAuth2_0AuthorizationServer.admin
{
    public partial class clientes_edicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Guid guid = Guid.NewGuid();
                tbClienteID.Text = guid.ToString();
            }
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}