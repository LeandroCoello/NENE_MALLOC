using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class ListadoCliente : Form
    {
        SQLConnector conexion = new SQLConnector();
        string criterioABM;
        public ListadoCliente(string condicion)
        {
            InitializeComponent();
            cBtipoIdent.Items.Add("DNI");
            cBtipoIdent.Items.Add("PASAPORTE");
            criterioABM = condicion;
        }



        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtApe.Text = "";
            txtMail.Text = "";
            txtNDoc.Text = "";
            txtNom.Text = "";
            cBtipoIdent.SelectedIndex = -1;
            dGVListadoSeleccionados.DataSource = null;
            dGVListadoSeleccionados.Columns.Clear();
            dGVListadoSeleccionados.Refresh();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string queryFinal = "SELECT * FROM NENE_MALLOC.Datos_Personales DP, NENE_MALLOC_Cliente C WHERE DP.Datos_Id = C.Cliente_Datos";
            string agregarCondicion;
            if(!string.IsNullOrEmpty(txtApe.Text)){
                agregarCondicion = "and DP.Datos_Apellido LIKE %"+txtApe.Text+"%";
                queryFinal += agregarCondicion;
            }
            if (!string.IsNullOrEmpty(txtNom.Text))
            {
                agregarCondicion = "and DP.Datos_Nombre LIKE %" + txtNom.Text + "%";
                queryFinal += agregarCondicion;
            }
            if (!string.IsNullOrEmpty(txtNDoc.Text))
            {
                agregarCondicion = "and DP.Datos_Nro_Ident LIKE %" + txtNDoc.Text + "%";
                queryFinal += agregarCondicion;
            }
            if (!string.IsNullOrEmpty(txtMail.Text))
            {
                agregarCondicion = "and DP.Datos_Mail LIKE %" + txtMail.Text + "%";
                queryFinal += agregarCondicion;
            }
            if(!string.IsNullOrEmpty(cBtipoIdent.SelectedItem.ToString()))
            {
                agregarCondicion = "and DP.Datos_Tipo_Ident =" + cBtipoIdent.SelectedItem.ToString();
                queryFinal += agregarCondicion;
            }
                /*GROUP BY??????*/
            dGVListadoSeleccionados.DataSource = conexion.consulta(queryFinal);
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.UseColumnTextForButtonValue = true;
            col.Text = "Seleccionar";
            col.Name = "Seleccionar";
            dGVListadoSeleccionados.Columns.Add(col);
            
        }
        private void dGVListadoSeleccionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (criterioABM == "baja")
                {
                    BajaCliente levantarBaja = new BajaCliente();
                    this.Close();
                    levantarBaja.Show();
                }
                else 
                {
                    ModifCliente levantarModif = new ModifCliente();
                    this.Close();
                    levantarModif.Show();
                }
            }
        }


    }
}
