using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class PantallaListado : Form
    {
        SQLConnector conexion;
        string criterioABM;
        public PantallaListado(string criterio, SQLConnector conec)
        {
            InitializeComponent();
            criterioABM = criterio;
            conexion = conec;
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
        }
    }
}
