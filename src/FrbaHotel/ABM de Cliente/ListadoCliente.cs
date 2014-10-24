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
    public partial class ListadoCliente : Form
    {
        public ListadoCliente(string condicion)
        {
            InitializeComponent();
            cBtipoIdent.Items.Add("DNI");
            cBtipoIdent.Items.Add("PASAPORTE");
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
            string queryFinal = "SELECT * FROM NENE_MALLOC.Datos_Personales DP, NENE_MALLOC_Cliente C WHERE /*ACA VAN LAS VALIDACIONES PERRA*/";

        }


    }
}
