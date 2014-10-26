using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class ListEstadistico : Form
    {
        SQLConnector conector;
        public ListEstadistico()
        {
            InitializeComponent();
            cBListado.Items.Add("Hoteles con mayor cantidad de reservas canceladas");
            cBListado.Items.Add("Hoteles con mayor cantidad de consumibles facturados");
            cBListado.Items.Add("Hoteles con mayor cantidad de días fuera de servicio");
            cBListado.Items.Add("Habitaciones con mayor cantidad de días y veces que fueron ocupadas");
            cBListado.Items.Add("Clientes con mayor cantidad de puntos");
            conector = new SQLConnector();
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            cBListado.SelectedIndex = -1;
            dGVListEsta.ClearSelection();
        }


        private void btnLanzarConsulta_Click(object sender, EventArgs e)
        {    
            string queryFinal;
            switch (cBListado.SelectedItem.ToString()) 
            {  
                case "Hoteles con mayor cantidad de reservas canceladas":
                    queryFinal = "exec hoteles_reservas_mas_canceladas GO";
                    dGVListEsta.DataSource = conector.consulta(queryFinal);
                    break;
                case "Hoteles con mayor cantidad de consumibles facturados":
                    queryFinal = "exec hoteles_consumibles_facturados GO";
                    dGVListEsta.DataSource = conector.consulta(queryFinal);
                    break;
                case "Hoteles con mayor cantidad de días fuera de servicio":
                    queryFinal = "exec hoteles_fuera_de_servicio GO";
                    dGVListEsta.DataSource = conector.consulta(queryFinal);
                    break;
                case "Habitaciones con mayor cantidad de días y veces que fueron ocupadas":
                    queryFinal = "exec habitaciones_mas_ocupadas GO";
                    break;
                default:

                    break;
            }
        }
    }
}
