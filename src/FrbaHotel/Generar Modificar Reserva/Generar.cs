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
    public partial class Generar : Form
    {
        SQLConnector coneccion;
        UsuarioLogueado usuario;
        DateTime fechaSistema;
        DataTable hoteles;
        DataTable tiposHabs;
        Decimal precio = 0;
        string clienteId;
        public Generar(SQLConnector conec,String condicion)
        {
            InitializeComponent();
            coneccion = conec;
            inicializar();
        }
        public Generar(UsuarioLogueado userLog) {
            InitializeComponent();
            usuario = userLog;
            cBHoteles.Items.Add(usuario.getHotelAsignado());
            cBHoteles.Enabled = false;
            inicializar();
        }
        public void setClienteId(string cliente) {
            clienteId = cliente;
        }

        private void inicializar() {
            fechaSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]);
            inicioDateTimePicker1.Value = fechaSistema;
            finDateTimePicker.Value = fechaSistema.AddDays(1);
            hoteles = coneccion.consulta("SELECT Hotel_Id,Hotel_Recarga_Estrella FROM NENE_MALLOC.Hotel");
            foreach (DataRow dr in hoteles.Rows)
            {
                cBHoteles.Items.Add(dr["Hotel_ID"].ToString());
            }
        }

        private void cBHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBHoteles.SelectedIndex != -1)
            {
                tiposHabs = coneccion.consulta("SELECT TH.Tipo_Hab_Desc,TH.Tipo_Hab_Porc FROM NENE_MALLOC.Habitacion H,NENE_MALLOC.Tipo_Habitacion TH WHERE H.Habitacion_Tipo = TH.Tipo_Hab_Id AND H.Habitacion_Hotel = " + cBHoteles.SelectedItem + " GROUP BY TH.Tipo_Hab_Desc,TH.Tipo_Hab_Porc");
                foreach (DataRow dr in tiposHabs.Rows)
                {
                    cBtiposHabs.Items.Add(dr["Tipo_Hab_Desc"].ToString());
                }
                dGVRegimen.DataSource = coneccion.consulta("SELECT R.Regimen_Desc,R.Regimen_Precio FROM NENE_MALLOC.Regimen R,NENE_MALLOC.Regimen_Por_Hotel RH WHERE R.Regimen_Id = RH.Regimen_Id AND R.Regimen_Inactivo = 0 AND RH.Hotel_Id = " + cBHoteles.SelectedItem);
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (cBHoteles.SelectedIndex == -1 || dGVRegimen.SelectedCells == null || cBtiposHabs.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos");
            }
            else {
                string query = "SELECT TH.Tipo_Hab_Desc,H.Habitacion_Piso,H.Habitacion_Vista,H.Habitacion_Id,H.Habitacion_Num FROM NENE_MALLOC.Habitacion H,NENE_MALLOC.Tipo_Habitacion TH,NENE_MALLOC.Regimen_Por_Hotel RH WHERE Habitacion_Cerrada != 1 AND Habitacion_Ocupada != 1"
                    + "AND H.Habitacion_Hotel = " + cBHoteles.SelectedItem + " AND TH.Tipo_Hab_Desc = '" + cBtiposHabs.SelectedItem + "' GROUP BY TH.Tipo_Hab_Desc,H.Habitacion_Piso,H.Habitacion_Vista,H.Habitacion_Id,H.Habitacion_Num";
                try
                {
                    dataGridView1.DataSource = coneccion.consulta(query);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Elija una habitacion para generar la reserva");
            }
            else {

                foreach (DataGridViewRow dr in dataGridView1.SelectedRows) {
                     precio += this.calcularPrecio();
                }
                if (confirmarReserva(precio) == DialogResult.Yes)
                {
                    if (clienteEnSistema() == DialogResult.Yes) {
                        BuscarCliente levantarBusqueda = new BuscarCliente(usuario,this);
                        this.Hide();
                        levantarBusqueda.ShowDialog();
                        MessageBox.Show("El cliente que quiere la reserva es:"+clienteId);
                        string query = "EXEC NENE_MALLOC.generar_reserva";
                    }
                }
                else {
                    DialogResult resul = MessageBox.Show("La reserva no se ha efectuado desea hacer otra ?","confirmacion",MessageBoxButtons.YesNo);
                    if (resul == DialogResult.Yes)
                    {
                        limpiarTODO();
                    }
                    else {
                        this.Close();
                    }
                }
             
            }
        }

        private void limpiarTODO() {
            cBtiposHabs.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dGVRegimen.Refresh();
        }

        private DialogResult confirmarReserva(Decimal unPrecio) {
             DialogResult resultado = MessageBox.Show("La reserva cuesta: " + unPrecio.ToString() + " u$s.\n ¿Desea confimar ?", "confirmacion", MessageBoxButtons.YesNo);
             return resultado;
        }
        private DialogResult clienteEnSistema() {
            return MessageBox.Show("¿Esta registrado en nuestra cadena hotelera?","confirmacion",MessageBoxButtons.YesNo);
        }
        private Decimal calcularPrecio() {
            Decimal porcHab =0;
            Decimal recargaHotel = 0;
            Decimal valorRegimen = 0;
            foreach (DataRow dr in tiposHabs.Rows) {
                if (dr["Tipo_Hab_Desc"].ToString() == cBtiposHabs.SelectedItem.ToString())
                {
                    porcHab = Convert.ToDecimal(dr["Tipo_Hab_Porc"]);
                }
            }
            foreach (DataRow dr in hoteles.Rows)
            {
                if(dr["Hotel_ID"].ToString()==cBHoteles.SelectedItem.ToString()){
                    recargaHotel = Convert.ToDecimal(dr["Hotel_Recarga_Estrella"]);
                }
            }
            foreach (DataGridViewRow dr in dGVRegimen.SelectedRows) {
                valorRegimen = Convert.ToDecimal(dr.Cells["Regimen_Precio"].Value);
            }

            return (valorRegimen*porcHab)+recargaHotel;
        }
    }
}
