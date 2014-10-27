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
    public partial class BajaHabitacion : Form
    {
        SQLConnector conexion = new SQLConnector();
        public BajaHabitacion()
        {
            InitializeComponent();
        }

        private void btnDARBAJA_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Habitacion set Habitacion_Cerrada = 1 WHERE FALTA EL ID PARA ACLARAR JOJO";
            conexion.executeOnly(query);
            MessageBox.Show("BAJA REALIZADA CON EXITO ");
            this.Close();
        }
    }
}
