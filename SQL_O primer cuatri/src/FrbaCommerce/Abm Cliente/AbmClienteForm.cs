using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class AbmClienteForm : Form
    {
        public AbmClienteForm()
        {
            InitializeComponent();
        }

        private void btnALTA_Click(object sender, EventArgs e)
        {
            Abm_Cliente.Alta levantarAlta = new Abm_Cliente.Alta();
            levantarAlta.ShowDialog();
            this.Hide();
        }

        private void btnMODIF_Click(object sender, EventArgs e)
        {
            Abm_Cliente.Filtrado levantarFiltro = new Abm_Cliente.Filtrado();
            levantarFiltro.ShowDialog();
            this.Hide();
        }

        private void btnBAJA_Click(object sender, EventArgs e)
        {
            Abm_Cliente.Filtrado levantarFiltro = new Abm_Cliente.Filtrado();
            levantarFiltro.ShowDialog();
            this.Hide();
        }
    }
}
