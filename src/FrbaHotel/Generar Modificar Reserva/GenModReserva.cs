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
    public partial class GenModReserva : Form
    {
        SQLConnector conexion = new SQLConnector();
        public GenModReserva()
        {
            InitializeComponent();
            DataTable tiposHabs = conexion.consulta("select Tipo_Hab_Desc FROM NENE_MALLOC.Tipo_Habitacion");
            foreach(DataRow dr in tiposHabs.Rows){
                cBtiposHabs.Items.Add(dr["Tipo_Hab_Desc"].ToString());
            }
            txtFecSist.Text = "ARCHIVO CONFIGURACION I NEED YOU";
        }
    }
}
