using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaEmpresa levantarAlta = new AltaEmpresa();
            levantarAlta.ShowDialog();
            this.Hide();
        }
        private void btnBaja_Click(object sender, EventArgs e)
        {
            FiltradoEmpresa levantarFiltro = new FiltradoEmpresa();
            levantarFiltro.ShowDialog();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FiltradoEmpresa levantarFiltro = new FiltradoEmpresa();
            levantarFiltro.ShowDialog();
            this.Hide();
        }




    }
}
