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


namespace FrbaHotel.Cancelar_Reserva
{
    public partial class CancelReser : Form
    {
        DateTime fechaActualSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]);
        SQLConnector conexion;
        public CancelReser(SQLConnector conecc,string criterio)
        {
            InitializeComponent();
            txtFecCancel.Text = fechaActualSistema.ToString("yyyyMMdd");
            conexion = conecc;
            if (criterio == "guest") 
            {   txtIDRecepcionista.ReadOnly = true;
                txtIDRecepcionista.Text = null;
            }
        }

        private void btnAceptarCancel_Click(object sender, EventArgs e)
        {
        string queryCancel = "";
        if (txtIDRecepcionista.ReadOnly == true)
        {
            queryCancel = "EXEC NENE_MALLOC.cancelar_reserva '" + txtFecCancel.Text + "'," + txtNroReserva.Text + ",NULL,'" + txtMotivo.Text + "'";
        }
        else { queryCancel = "EXEC NENE_MALLOC.cancelar_reserva '" + txtFecCancel.Text + "'," + txtNroReserva.Text + "," + txtIDRecepcionista.Text + ",'" + txtMotivo.Text + "'"; 
        }
            if (string.IsNullOrEmpty(txtFecCancel.Text) || string.IsNullOrEmpty(txtMotivo.Text) || string.IsNullOrEmpty(txtNroReserva.Text) ||
                string.IsNullOrEmpty(txtIDRecepcionista.Text))
            {
                MessageBox.Show("Por favor complete todo los campos");
                this.limpiarCampos();
            }
            else 
            {
                try {
                   
                    conexion.executeOnly(queryCancel);
                    MessageBox.Show("Reserva Cancelada con exito");
                    this.Close();
                }
                catch (Exception ex) { 
                    MessageBox.Show(ex.Message); 
                }
            }
           
        }
        private void limpiarCampos() { txtNroReserva.Text = ""; txtMotivo.Text = ""; txtIDRecepcionista.Text = ""; }

    }
}
