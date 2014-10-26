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
    public partial class BajaCliente : Form
    {
        SQLConnector conexion = new SQLConnector();
        public BajaCliente()
        {
            InitializeComponent();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            string queryViolento = "UPDATE NENE_MALLOC.Cliente set Cliente_Deshabilitado = 1 WHERE Cliente_Id ="+
                "ACA PONER LA ID QUE RECIBIO DE LA DATATABLE";
            conexion.executeOnly(queryViolento);
            MessageBox.Show("Cliente dado de baja con exito!");
        }

    }
}
