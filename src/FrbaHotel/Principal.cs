using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel
{
    public partial class Principal : Form
    {
        private SQLConnector coneccion;
        public Principal()
        {
            InitializeComponent();
            coneccion = new SQLConnector();
        }

        private void btnExecRegistro_Click(object sender, EventArgs e)
        {
            FrbaHotel.Generar_Modificar_Reserva.GenModReserva levantarReserva = new FrbaHotel.Generar_Modificar_Reserva.GenModReserva(coneccion);
            this.Hide();
            levantarReserva.ShowDialog();
            this.Show();
        }

        private void btnExecLogin_Click(object sender, EventArgs e)
        {
            FrbaHotel.Login.Login levantarLogeo = new FrbaHotel.Login.Login(coneccion);
            this.Hide();
            levantarLogeo.ShowDialog();
            this.Show();
        }

    }
}
