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

namespace FrbaHotel.Facturar_Publicaciones
{
    public partial class FacturarPublicaciones : Form
    {
        UsuarioLogueado usuario;
        String fechaSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]).ToString("yyyyMMdd"); 
        public FacturarPublicaciones(UsuarioLogueado userLog)
        {
            InitializeComponent();
            btnFacturar.Enabled = false;
            usuario = userLog;
            cBFormaPago.Items.Add("Efectivo");
            cBFormaPago.Items.Add("Tarjeta credito");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtClieCod.Text == "")
            {
                MessageBox.Show("Ingrese cliente");
            }
            else
            {
                string query = "SELECT * FROM NENE_MALLOC.Reserva_Por_Habitacion,NENE_MALLOC.Reserva,NENE_MALLOC.Estadia,NENE_MALLOC.Item_Factura WHERE Reserva_Cliente =" + txtClieCod.Text + " AND Reserva_Hotel =" + usuario.getHotelAsignado() + " AND Reserva.Reserva_Id = Reserva_Por_Habitacion.Reserva_Id AND Reserva_Por_Habitacion.RPH_Id = Estadia.Estadia_RPH AND Item_Factura.Item_Factura_Id = Estadia.Estadia_Id AND Item_Factura.Item_Factura IS NULL";
                dataGridViewEsta.DataSource = usuario.getConexion().consulta(query);
            }
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtClieCod.Text = "";
            cBFormaPago.SelectedIndex = -1;
            dataGridViewEsta.DataSource = null;
            dataGridViewEsta.Refresh();
            dataGridViewConsu.DataSource = null;
            dataGridViewConsu.Refresh();
        }

        private void btnBuscarConsu_Click(object sender, EventArgs e)
        {
            btnFacturar.Enabled = true;
            foreach (DataGridViewRow dr in dataGridViewEsta.SelectedRows) {
                string RPH_ID = dr.Cells["RPH_Id"].Value.ToString();
                string query = "SELECT Consumible.Consumible_Desc,Consumible_Por_Habitacion.Consumible_Cantidad FROM NENE_MALLOC.Consumible_Por_Habitacion,NENE_MALLOC.Consumible WHERE Consumible_Por_Habitacion.RPH_Id ="+RPH_ID+"AND Consumible.Consumible_Id = Consumible_Por_Habitacion.Consumible_Id";
                dataGridViewConsu.DataSource = usuario.getConexion().consulta(query);
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            Decimal total = 0;
            string queryFinal = "declare @total numeric(18,0) EXEC NENE_MALLOC.generar_factura "+txtClieCod.Text+","+fechaSistema+",@total out"
                                +"SELECT @total";
            total = Convert.ToDecimal(usuario.getConexion().consulta(queryFinal).Rows[0].ItemArray[0]);

            MessageBox.Show("Cliente: "+txtClieCod.Text
                            +"\n Estadia:"+dataGridViewEsta.SelectedRows.ToString()
                            +"\n Consumibles:"+dataGridViewConsu.ToString()
                            +"\n total:"+total.ToString());

            this.btnLimpieza_Click(sender,e);
        }


    }
}
