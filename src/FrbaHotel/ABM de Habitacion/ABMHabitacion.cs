using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class ABMHabitacion : Form
    {
        SQLConnector conexion;
        public ABMHabitacion(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            ABM_de_Habitacion.HabitacionAlta levantarAlta = new HabitacionAlta(conexion);
            this.Hide();
            levantarAlta.ShowDialog();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListadoHabitacion levantarListado = new ListadoHabitacion("modificar",conexion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoHabitacion levantarListado = new ListadoHabitacion("baja",conexion);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();

        }
    }
}
