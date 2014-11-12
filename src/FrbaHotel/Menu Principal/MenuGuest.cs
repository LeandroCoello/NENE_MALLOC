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
        UsuarioLogueado userLog;
        public MenuGuest(UsuarioLogueado usuario)
        {
            InitializeComponent();
            userLog = usuario;
        }

        private void btnGENMODRESER_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.GenModReserva levantarGenMod = new FrbaHotel.Generar_Modificar_Reserva.GenModReserva(userLog.getConexion());
            this.Hide();
            levantarGenMod.ShowDialog();
            this.ShowDialog();
        }
    }
}
