using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ListadoCliente : Form
    {
        public ListadoCliente(string condicion)
        {
            InitializeComponent();
        }

        private void dGVListadoSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtApe.Text = "";
            txtMail.Text = "";
            txtNDoc.Text = "";
            txtNom.Text = "";
            cBtipoIdent.SelectedIndex = -1;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {

        }


    }
}
