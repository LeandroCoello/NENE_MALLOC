using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class PantallaListado : Form
    {
        SQLConnector conexion;
        string criterioABM;
        public PantallaListado(string criterio, SQLConnector conec)
        {
            InitializeComponent();
            criterioABM = criterio;
            conexion = conec;
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            txtNom.Text = "";
            cBEstado.SelectedIndex = -1;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string queryFinal="SELECT * FROM NENE_MALLOC.Usuario";
            if (!string.IsNullOrEmpty(txtNom.Text)) {
                queryFinal += "WHERE Usuario_name = '"+txtNom.Text+"'";
                if (cBEstado.SelectedIndex != -1) {
                    queryFinal += "AND Usuario_baja =" + cBEstado.SelectedText;
                }
            }
            else if(cBEstado.SelectedIndex != -1){
                queryFinal += "WHERE Usuario_baja ="+cBEstado.SelectedText;
                if (!string.IsNullOrEmpty(txtNom.Text))
                {
                    queryFinal += "AND Usuario_name = '" + txtNom.Text + "'";
                }
            }

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
                    BajaUsuario levantarBaja = new BajaUsuario(valor, conexion);
                    levantarBaja.Show();
                    this.Close();
                }
                else
                {
                    ModificarUsuario levantarModif = new ModificarUsuario(valor, conexion);
                    levantarModif.Show();
                    this.Close();
                }
            }
        }
    }
}
