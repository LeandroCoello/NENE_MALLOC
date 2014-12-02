using System;
using System.Configuration;
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
        DateTime fechaSistema;
        string hotelID;
        string condi=null;
        string clienteId;
        string idTipoHab;
        string idregmin;
        public Modificar(SQLConnector conec,String condicion)
        {
            InitializeComponent();
            conexion = conec;
            condi = condicion;
            inicializar();
        }
        public Modificar(UsuarioLogueado user) {
            InitializeComponent();
            usuario = user;
            conexion = usuario.getConexion();
            inicializar();
        }
        private void inicializar() {
            fechaSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]);
            dateTimePicker1.Value = fechaSistema;
            dateTimePicker2.Value = fechaSistema.AddDays(1);
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
            Regimenes levantarRegimenes = new Regimenes(txtCodReser.Text,regimenes,this);
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
                hotelID = dataGridView1.Rows[0].Cells["H.Habitacion_Hotel"].Value.ToString();
                setClienteIdyRegimenId();
                dataGridView1.DataSource = conexion.consulta(query);
                txtRegimenActual.Text = dataGridView1.Rows[0].Cells["R.Reserva_Regimen"].Value.ToString();
                txtHabActual.Text = dataGridView1.Rows[0].Cells["H.Habitacion_Tipo"].Value.ToString();
                string habitacionesDisp = "SELECT H.Habitacion_Num,H.Habitacion_Piso,H.Habitacion_Hotel,H.Habitacion_Tipo,H.Habitacion_Vista,H.Habitacion_Desc FROM NENE_MALLOC.Habitacion H WHERE H.Habitacion_Ocupada = 0 AND H.Habitacion_Cerrada = 0 AND H.Habitacion_Hotel = "+hotelID;
                dataGridView2.DataSource = conexion.consulta(habitacionesDisp);
                tiposHabs = conexion.consulta("SELECT TH.Tipo_Hab_Desc,TH.Tipo_Hab_Porc FROM NENE_MALLOC.Habitacion H,NENE_MALLOC.Tipo_Habitacion TH WHERE H.Habitacion_Tipo = TH.Tipo_Hab_Id AND H.Habitacion_Hotel = " + hotelID+" GROUP BY TH.Tipo_Hab_Desc");
                regimenes = conexion.consulta("SELECT R.Regimen_Id,R.Regimen_Desc,R.Regimen_Precio FROM NENE_MALLOC.Regimen R,NENE_MALLOC.Regimen_Por_Hotel RH WHERE R.Regimen_Id = RH.Regimen_Id AND R.Regimen_Inactivo = 0 AND RH.Hotel_Id = " + hotelID);
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

        private void btnModificarReser_Click(object sender, EventArgs e)
        {
            if (condi == null)
            {
                string query = "declare @idReserva numeric(18,0) EXEC NENE_MALLOC.modificar_reserva '" + fechaSistema + "','" + dateTimePicker1.Value.ToString("yyyy/MM/dd")
                    + "','" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'," + idregmin + "," + clienteId + "," + hotelID + "," + usuario.conseguirIdUser() + ",@regimenId out" +
                    " SELECT @idReserva";
                DataTable idReser = conexion.consulta(query);
                MessageBox.Show("Reserva modificada exitosamente.");
            }
            else
            {
                string query = "declare @idReserva numeric(18,0) EXEC NENE_MALLOC.modificar_reserva '" + fechaSistema + "','" + dateTimePicker1.Value.ToString("yyyy/MM/dd")
                         + "','" + dateTimePicker2.Value.ToString("yyyy/MM/dd") + "'," + idregmin + "," + clienteId + "," + hotelID + ",NULL, @regimenId out" +
                        " SELECT @idReserva";
                DataTable idReser = conexion.consulta(query);
                MessageBox.Show("Reserva modificada exitosamente.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void setClienteIdyRegimenId() {
            string query = "SELECT R.Reserva_Cliente,R.Reserva_Regimen FROM NENE_MALLOC.Reserva R WHERE R.Reserva_Id =" + txtCodReser.Text;
            DataTable ids = conexion.consulta(query);
            foreach (DataRow dr in ids.Rows) {
                clienteId = dr["Reserva_Cliente"].ToString();
                idregmin = dr["Reserva_Regimen"].ToString();
            }
        }
        public void setearNuevoRegimen(DataGridViewRow row) {
            idregmin = row.Cells["Regimen_Id"].Value.ToString();
            txtRegimenActual.Text = row.Cells["Regimen_Desc"].Value.ToString();
        }
        /*private Decimal calcularPrecio()
        {
            Decimal porcHab = 0;
            Decimal recargaHotel = 0;
            Decimal valorRegimen = 0;
            foreach (DataRow dr in tiposHabs.Rows)
            {
                if (dr["Tipo_Hab_Desc"].ToString() == cBtiposHabs.SelectedItem.ToString())
                {
                    porcHab = Convert.ToDecimal(dr["Tipo_Hab_Porc"]);
                }
            }
            foreach (DataRow dr in hoteles.Rows)
            {
                if (dr["Hotel_ID"].ToString() == cBHoteles.SelectedItem.ToString())
                {
                    recargaHotel = Convert.ToDecimal(dr["Hotel_Recarga_Estrella"]);
                }
            }
            foreach (DataGridViewRow dr in dGVRegimen.SelectedRows)
            {
                valorRegimen = Convert.ToDecimal(dr.Cells["Regimen_Precio"].Value);
                regimenId = Convert.ToString(dr.Cells["Regimen_Id"].Value);

            }

            return (valorRegimen * porcHab) + recargaHotel;
        }*/
    }
}
