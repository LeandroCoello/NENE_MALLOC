using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnExecRegistro_Click(object sender, EventArgs e)
        {
            FrbaHotel.Registrar_Estadia.RegEstadia levantarEstadia = new FrbaHotel.Registrar_Estadia.RegEstadia();
            this.Hide();
            levantarEstadia.ShowDialog();
            this.Show();
            
        }

        private void btnExecLogin_Click(object sender, EventArgs e)
        {
            FrbaHotel.Login.Login levantarLogeo = new FrbaHotel.Login.Login();
            this.Hide();
            levantarLogeo.ShowDialog();
            this.Show();
        }

    }
}
