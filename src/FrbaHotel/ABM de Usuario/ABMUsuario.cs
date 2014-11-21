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
    public partial class ABMUsuario : Form
    {
        SQLConnector conexion;
        public ABMUsuario(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaUsuario levantarAlta = new AltaUsuario(conexion);
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            PantallaListado levantarListado = new PantallaListado("modificar",conexion);           
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            PantallaListado levantarListado = new PantallaListado("baja", conexion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }
    }
}
