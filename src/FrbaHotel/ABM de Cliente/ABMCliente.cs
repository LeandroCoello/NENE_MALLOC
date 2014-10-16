using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.AltaCliente levantarAlta = new AltaCliente();
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListadoCliente levantarListado = new ListadoCliente("modificar");
            this.Hide();
            levantarListado.Show();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoCliente levantarListado = new ListadoCliente("baja");
            this.Hide();
            levantarListado.Show();
            this.Show();
        }
    }
}
