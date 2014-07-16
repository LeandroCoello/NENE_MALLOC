using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Menu_Principal
{
    public partial class Form1MenuPrincipal : Form
    {
        public Form1MenuPrincipal(string rolAsignado)
        {
            InitializeComponent();
            if (rolAsignado == "Cliente")
            { 
              btnCompraOferta.Visible = true;
              btnCalificar.Visible = true;
            }
        }

        private void btnCompraOferta_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearPub_Click(object sender, EventArgs e)
        {

        }

        private void btnEditPub_Click(object sender, EventArgs e)
        {

        }

    }
}
