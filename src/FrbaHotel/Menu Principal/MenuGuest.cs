using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Menu_Principal
{
    public partial class MenuGuest : Form
    {
        SQLConnector conexion;
        public MenuGuest(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

        private void btnGENMODRESER_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.GenModReserva levantarGenMod = new FrbaHotel.Generar_Modificar_Reserva.GenModReserva(conexion);
            this.Hide();
            levantarGenMod.ShowDialog();
            this.ShowDialog();
        }

        private void bnCancelGuest_Click(object sender, EventArgs e)
        {
            Cancelar_Reserva.CancelReser levantarCancel = new FrbaHotel.Cancelar_Reserva.CancelReser(conexion,"guest");
            this.Hide();
            levantarCancel.ShowDialog();
            this.Show();
            
        }
    }
}
