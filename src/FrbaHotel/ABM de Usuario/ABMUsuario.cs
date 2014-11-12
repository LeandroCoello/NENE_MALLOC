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
        SQLConnector coneccion;
        public ABMUsuario(SQLConnector conexion)
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaUsuario levantarAlta = new AltaUsuario();
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarUsuario levantarModif = new ModificarUsuario();
            this.Hide();
            levantarModif.ShowDialog();
            this.Show();
        }

        private void btnBajar_Click(object sender, EventArgs e)
        {
            BajaUsuario levantarBaja = new BajaUsuario();
            this.Hide();
            levantarBaja.ShowDialog();
            this.Show();
        }
    }
}
