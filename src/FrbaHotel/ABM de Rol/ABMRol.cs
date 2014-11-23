using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ABMRol : Form
    {
        SQLConnector conexion;
        public ABMRol(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaRol levantaAlta = new AltaRol(conexion);
            this.Hide();
            levantaAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListadoRol levantarListado = new ListadoRol("modificar",conexion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoRol levantarListado = new ListadoRol("baja",conexion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show(); 
        }
    }
}
