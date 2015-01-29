using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Facturar_Publicaciones
{
    public partial class TarjetaDeCredito : Form
    {
        String facturaID;
        String tipoDeTarjeta;
        public TarjetaDeCredito(String codigoCliente,String facturaIDIn)
        {

            InitializeComponent();
            label2.Text = codigoCliente;
            facturaID = facturaIDIn;
            tipoTarjeta.Items.Add("Master Card");
            tipoTarjeta.Items.Add("VISA");
            tipoTarjeta.Items.Add("American Express");
            tipoTarjeta.Items.Add("Otro");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tipoDeTarjeta = tipoTarjeta.SelectedItem.ToString();
                if (tipoTarjeta.SelectedItem.ToString()== "Otro")
                {
                    //Lanzo una ventanita extra que pida una marca de tarjeta nueva
                }
                //exec query procedure

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
