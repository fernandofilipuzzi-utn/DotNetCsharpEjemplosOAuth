﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OAuth2_0AuthorizationServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Server.MapPath("~/carpeta/archivos");
        }
    }
}