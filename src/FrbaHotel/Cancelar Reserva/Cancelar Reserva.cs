using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;
using System.Configuration;

namespace FrbaHotel.Cancelar_Reserva
{
    public partial class CancelReser : Form
    {
        //ESTO ES SOLO POR AHORA LA FECHA SE LA PEDIMOS AL ARCHIVO DE CONFIGURACION
        
        System.DateTime fechaActualSistema = new DateTime();
        public CancelReser(SQLConnector conecc)
        {
            InitializeComponent();
            txtFecCancel.Text = fechaActualSistema.ToString();
        }

        private void btnAceptarCancel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFecCancel.Text) || string.IsNullOrEmpty(txtMotivo.Text) || string.IsNullOrEmpty(txtNroReserva.Text) ||
                string.IsNullOrEmpty(txtIDRecepcionista.Text))
            {
                MessageBox.Show("Por favor complete todo los campos");
                this.limpiarCampos();
            }
            else 
            {
                this.ejecutarCancelacion();
            }
           
        }
        private void limpiarCampos() { txtNroReserva.Text = ""; txtMotivo.Text = ""; txtIDRecepcionista.Text = ""; }

        private void ejecutarCancelacion()
        {//TRIGGER DE SQL PARA VALIDAR FECHAS????
            /*string queryObtenerFechaIngreso = "SELECT Reserva_FechaIng FROM NENE_MALLOC.Reserva" +
                "WHERE Reserva.Reserva_Cliente =" + txtNUsuario.Text + "and Reserva.Reserva_Id =" + txtNroReserva.Text;
            System.DateTime fechaDeReserva = DateTime.TryParse(conexion.consulta(queryObtenerFechaIngreso).Rows[0].ItemArray[0]);
            string queryCancelacion = "UPDATE NENE_MALLOC.Reserva set Reserva_Estado = 'Cancelada' Where WHERE Reserva.Reserva_Cliente =" + txtNUsuario.Text + "and Reserva.Reserva_Id =" + txtNroReserva.Text + " GO";*/
        }
    }
}
