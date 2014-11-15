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
    public partial class ListadoHabitacion : Form
    {
        SQLConnector conexion;
        public ListadoHabitacion(string criterio,SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            DataTable tiposHab = conexion.consulta("SELECT select Habitacion_Tipo FROM NENE_MALLOC.Habitacion GROUP BY Habitacion_Tipo");
            foreach (DataRow dr in tiposHab.Rows)
            {
                cBTipoHabitacion.Items.Add(dr["Habitacion_Tipo"].ToString());
            }
            cBVista.Items.Add("SI");
            cBVista.Items.Add("NO");
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtHotel.Text = "";
            txtPisoHotel.Text = "";
            cBTipoHabitacion.SelectedIndex = -1;
            cBVista.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string queryFinal = "select * FROM NENE_MALLOC.Habitacion";
            queryFinal = this.armarCondiciones();

            dataGridView1.DataSource = conexion.consulta(queryFinal);
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Seleccionar";
            col.Name = "Seleccionar";
            dataGridView1.Columns.Add(col);

        }
        private string armarCondiciones() {
            /*TERMINA DE CODEARME NO SEAS MALO :(*/
            return "hola";
        }
    }
}
