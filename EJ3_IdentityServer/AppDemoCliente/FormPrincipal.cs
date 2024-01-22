using AppDemoCliente.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDemoCliente
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            APIEjClient servicio = new APIEjClient();
            tbRespuesta.Text= servicio.GetDato().Result;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            APIEjClientRestSharp servicio = new APIEjClientRestSharp();
            tbRespuesta.Text = servicio.GetDato();
        }
    }
}
