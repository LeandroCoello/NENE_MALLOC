using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class BuscarCliente : Form
    {
        UsuarioLogueado usuario;
        string clienteId;
        Generar generarForm;
        public BuscarCliente(UsuarioLogueado userLog,Generar genForm)
        {
            InitializeComponent();
            usuario = userLog;
            cBTipoDoc.Items.Add("DNI");
            cBTipoDoc.Items.Add("Pasaporte");
            cBTipoDoc.Items.Add("Cedula");
            generarForm = genForm;
        }

        private void btnBusquedaClie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNDoc.Text) || string.IsNullOrEmpty(txtMail.Text) || cBTipoDoc.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos");
            }
            else {
                string query = "SELECT * FROM NENE_MALLOC.Cliente C,NENE_MALLOC.Datos_Personales DP WHERE C.Cliente_Datos = DP.Datos_Id"+
                    " AND DP.Datos_Mail LIKE '%"+txtMail.Text+"%'"+
                    " AND DP.Datos_Tipo_Ident LIKE '%"+cBTipoDoc.SelectedItem.ToString()+"%'"+
                    " AND DP.Datos_Nro_Ident ="+txtNDoc.Text;
                dataGridView1.DataSource = usuario.getConexion().consulta(query);
                DataGridViewButtonColumn col = new DataGridViewButtonColumn();
                col.UseColumnTextForButtonValue = true;
                col.Text = "Seleccionar";
                col.Name = "Seleccionar";
                dataGridView1.Columns.Add(col);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string[] valor = new string[e.ColumnIndex];

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                clienteId = dataGridView1.Rows[e.RowIndex].Cells["C.Cliente_Id"].Value.ToString();
                generarForm.setClienteId(clienteId);
                this.Close();
                
            }
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtMail.Text = "";
            txtNDoc.Text = "";
            cBTipoDoc.SelectedIndex = -1;
        }

    }
}
