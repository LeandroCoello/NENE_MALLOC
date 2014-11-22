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
    public partial class MenuAdmin : Form
    {
        UsuarioLogueado userLog;
        public MenuAdmin(UsuarioLogueado usuario)
        {
            InitializeComponent();
            userLog = usuario;
        }

        private void btnRol_Click(object sender, EventArgs e)
        {
            ABM_de_Rol.ABMRol levantarRol = new FrbaHotel.ABM_de_Rol.ABMRol(userLog.getConexion());
            this.Hide();
            levantarRol.ShowDialog();
            this.Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            ABM_de_Usuario.ABMUsuario levantarUsuario = new FrbaHotel.ABM_de_Usuario.ABMUsuario(userLog.getConexion());
            this.Hide();
            levantarUsuario.ShowDialog();
            this.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.ABMCliente levantarCliente = new FrbaHotel.ABM_de_Cliente.ABMCliente(userLog.getConexion());
            this.Hide();
            levantarCliente.ShowDialog();
            this.Show();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            ABM_de_Hotel.ABMHotel levantarHotel = new FrbaHotel.ABM_de_Hotel.ABMHotel(userLog.getConexion());
            this.Hide();
            levantarHotel.ShowDialog();
            this.Show();
        }

        private void btnHabitacion_Click(object sender, EventArgs e)
        {
            ABM_de_Habitacion.ABMHabitacion levantarHabitacion = new FrbaHotel.ABM_de_Habitacion.ABMHabitacion(userLog.getConexion(),userLog);
            this.Hide();
            levantarHabitacion.ShowDialog();
            this.Show();
        }

        private void btnREGIMEN_Click(object sender, EventArgs e)
        {
            ABM_de_Regimen.ABMRegimen levantarRegimen = new FrbaHotel.ABM_de_Regimen.ABMRegimen();
            this.Hide();
            levantarRegimen.ShowDialog();
            this.Show();
        }
    }
}
