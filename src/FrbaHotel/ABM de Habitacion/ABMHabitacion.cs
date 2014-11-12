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
        public ABMHabitacion(SQLConnector coneccion)
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            ABM_de_Habitacion.HabitacionAlta levantarAlta = new HabitacionAlta();
            this.Hide();
            levantarAlta.Show();
            this.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ListadoHabitacion levantarListado = new ListadoHabitacion("modificar");
            this.Hide();
            levantarListado.Show();
            this.Show();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ListadoHabitacion levantarListado = new ListadoHabitacion("baja");
            this.Hide();
            levantarListado.Show();
            this.Show();

        }
    }
}
