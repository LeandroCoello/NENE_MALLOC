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
        DateTime fechaSistema;
        public Generar(SQLConnector conec,String condicion)
        {
            InitializeComponent();
            coneccion = conec;
            fechaSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]);
            inicioDateTimePicker1.Value = fechaSistema;
            finDateTimePicker.Value = fechaSistema.AddDays(1);
        }

        private void cBHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBHoteles.SelectedIndex != -1)
            {
                DataTable tiposHabs = coneccion.consulta("SELECT TH.Tipo_Hab_Desc FROM NENE_MALLOC.Habitacion H,NENE_MALLOC.Tipo_Habitacion TH WHERE H.Habitacion_Tipo = TH.Tipo_Hab_Id AND H.Habitacion_Hotel = "+cBHoteles.SelectedItem);
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
                    + "AND H.Habitacion_Hotel =" + cBHoteles.SelectedItem + "AND AND TH.Tipo_Hab_Desc = '"+cBtiposHabs.SelectedItem+"'";
            }
        }
    }
}
