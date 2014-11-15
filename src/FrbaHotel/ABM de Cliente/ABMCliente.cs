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
        SQLConnector coneccion;
        public ABMCliente(SQLConnector conexion)
        {
            InitializeComponent();
            coneccion = conexion;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            FrbaHotel.ABM_de_Cliente.AltaCliente levantarAlta = new AltaCliente(coneccion);
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListadoCliente levantarListado = new ListadoCliente("modificar", coneccion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoCliente levantarListado = new ListadoCliente("baja",coneccion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }
    }
}
