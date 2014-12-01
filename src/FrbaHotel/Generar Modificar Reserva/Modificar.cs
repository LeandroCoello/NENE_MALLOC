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
    public partial class Modificar : Form
    {
        SQLConnector conexion;
        UsuarioLogueado usuario;
        DataTable tiposHabs;
        DataTable regimenes;
        public Modificar(SQLConnector conec,String condicion)
        {
            InitializeComponent();
            conexion = conec;
        }
        public Modificar(UsuarioLogueado user) {
            InitializeComponent();
            usuario = user;
            conexion = usuario.getConexion();
        }


        private void btnCambiarTipoHab_Click(object sender, EventArgs e)
        {
            Tipos_Habitaciones levantarTipos = new Tipos_Habitaciones(txtHabActual.Text,tiposHabs);
            this.Hide();
            levantarTipos.ShowDialog();
            this.Show();
        }

        private void btnCambiarRegimen_Click(object sender, EventArgs e)
        {
            Regimenes levantarRegimenes = new Regimenes(txtCodReser.Text,regimenes);
            this.Hide();
            levantarRegimenes.ShowDialog();
            this.Show();
        }

        private void btnBuscarReserva_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodReser.Text))
            {
                MessageBox.Show("Ingrese un codigo reserva");
            }
            else {
                string query = "SELECT H.Habitacion_Num,H.Habitacion_Piso,H.Habitacion_Hotel,H.Habitacion_Tipo,H.Habitacion_Vista,H.Habitacion_Desc,R.Reserva_Regimen FROM NENE_MALLOC.Reserva R, NENE_MALLOC.Reserva_Por_Habitacion RPH,NENE_MALLOC.Habitacion H WHERE H.Habitacion_Id = RPH.Habitacion_Id AND RPH.Reserva_Id =" + txtCodReser.Text+"AND R.Reserva_Id ="+txtCodReser.Text;
                string hotelID = dataGridView1.Rows[0].Cells["H.Habitacion_Hotel"].Value.ToString();
                dataGridView1.DataSource = conexion.consulta(query);
                txtRegimenActual.Text = dataGridView1.Rows[0].Cells["R.Reserva_Regimen"].Value.ToString();
                txtHabActual.Text = dataGridView1.Rows[0].Cells["H.Habitacion_Tipo"].Value.ToString();
                string habitacionesDisp = "SELECT H.Habitacion_Num,H.Habitacion_Piso,H.Habitacion_Hotel,H.Habitacion_Tipo,H.Habitacion_Vista,H.Habitacion_Desc FROM NENE_MALLOC.Habitacion H WHERE H.Habitacion_Ocupada = 0 AND H.Habitacion_Cerrada = 0 AND H.Habitacion_Hotel = "+hotelID;
                dataGridView2.DataSource = conexion.consulta(habitacionesDisp);
                tiposHabs = conexion.consulta("SELECT TH.Tipo_Hab_Desc,TH.Tipo_Hab_Porc FROM NENE_MALLOC.Habitacion H,NENE_MALLOC.Tipo_Habitacion TH WHERE H.Habitacion_Tipo = TH.Tipo_Hab_Id AND H.Habitacion_Hotel = " + hotelID+" GROUP BY TH.Tipo_Hab_Desc");
                regimenes = conexion.consulta("SELECT R.Regimen_Desc,R.Regimen_Precio FROM NENE_MALLOC.Regimen R,NENE_MALLOC.Regimen_Por_Hotel RH WHERE R.Regimen_Id = RH.Regimen_Id AND R.Regimen_Inactivo = 0 AND RH.Hotel_Id = " + hotelID);
            }
        }

        private void btnQuitarHab_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1) {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows) {
                    dataGridView1.Rows.RemoveAt(dr.Index);
                }
            }
        }
        private void btnAgregarHab_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count >= 1)
            {
                foreach (DataGridViewRow dr in dataGridView2.SelectedRows)
                {
                    dataGridView1.Rows.Add(dr);
                    dataGridView2.Rows.RemoveAt(dr.Index);
                }
            }
        }
    }
}
