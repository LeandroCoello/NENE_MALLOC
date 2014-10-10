using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ABMRol : Form
    {
        public ABMRol()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaRol levantaAlta = new AltaRol();
            this.Hide();
            levantaAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarRol levantarModif = new ModificarRol();
            this.Hide();
            levantarModif.ShowDialog();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            BajaRol levantarBaja = new BajaRol();
            this.Hide();
            levantarBaja.ShowDialog();
            this.Show();
        }
    }
}
