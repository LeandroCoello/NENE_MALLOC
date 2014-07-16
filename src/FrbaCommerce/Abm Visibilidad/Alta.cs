using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Alta : Form
    {
        SQLConnector conec;
        public Alta()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDuracion.Text) && !string.IsNullOrEmpty(txtDesc.Text)
                && !string.IsNullOrEmpty(txtPrecioPorPublicar.Text) && !string.IsNullOrEmpty(txtPorcentaje.Text)) 
                 {
                     conec = new SQLConnector();
                     string queryAlta = "exec SQL_O.alta_visibilidad '" + txtDesc.Text + "'" + "'" + txtDuracion.Text + "'" + "'" + txtPrecioPorPublicar.Text + "'" + "'" + txtPorcentaje.Text + "'";
                     conec.executeOnly(queryAlta);
                     MessageBox.Show("Nueva visibilidad creada con exito");
                 }
        }
    }
}
