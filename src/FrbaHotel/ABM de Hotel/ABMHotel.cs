using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;


namespace FrbaHotel.ABM_de_Hotel
{
    public partial class ABMHotel : Form
    {
        UsuarioLogueado usuario;
        public ABMHotel(UsuarioLogueado user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaHotel levantarAlta = new AltaHotel(usuario);
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoHotel levantarLista = new ListadoHotel("baja", usuario.getConexion());
            this.Hide();
            levantarLista.ShowDialog();
            this.Show();
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            ListadoHotel levantarLista = new ListadoHotel("modificar", usuario.getConexion());
            this.Hide();
            levantarLista.ShowDialog();
            this.Show();

        }
    }
}
