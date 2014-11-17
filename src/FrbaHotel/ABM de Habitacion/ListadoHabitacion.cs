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
        string criterioABM;
        public ListadoHabitacion(string criterio,SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            DataTable tiposHab = conexion.consulta("SELECT Habitacion_Tipo FROM NENE_MALLOC.Habitacion GROUP BY Habitacion_Tipo");
            foreach (DataRow dr in tiposHab.Rows)
            {
                cBTipoHabitacion.Items.Add(dr["Habitacion_Tipo"].ToString());
            }
            cBVista.Items.Add("SI");
            cBVista.Items.Add("NO");
            criterioABM = criterio;
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
            if (!String.IsNullOrEmpty(txtHotel.Text)) { }
            //ARMAR LAS CONDICIONES
            dataGridView1.DataSource = conexion.consulta(queryFinal);
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Seleccionar";
            col.Name = "Seleccionar";
            dataGridView1.Columns.Add(col);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string[] valor = new string[e.ColumnIndex];
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                for (int i = 0; i < e.ColumnIndex; i++)
                {
                    valor[i] = dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString();
                }

                if (criterioABM == "baja")
                {
                    BajaHabitacion levantarBaja = new BajaHabitacion(valor, conexion);
                    this.Close();
                    levantarBaja.Show();
                }
                else
                {
                    ModifHabitacion levantarModif = new ModifHabitacion(valor, conexion);
                    this.Close();
                    levantarModif.Show();
                }
            }
        }
    }
}
