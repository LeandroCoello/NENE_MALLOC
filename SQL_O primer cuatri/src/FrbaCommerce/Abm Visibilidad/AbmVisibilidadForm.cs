using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class AbmVisibilidadForm : Form
    {
        public AbmVisibilidadForm()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Alta levantarAlta = new Alta();
            levantarAlta.ShowDialog();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Filtrar levantarFiltro = new Filtrar();
            levantarFiltro.ShowDialog();
            this.Hide();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            Filtrar levantarFiltro = new Filtrar();
            levantarFiltro.ShowDialog();
            this.Hide();
        }
    }
}
