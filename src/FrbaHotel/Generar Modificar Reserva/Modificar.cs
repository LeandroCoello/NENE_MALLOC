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
    public partial class Modificar : Form
    {
        SQLConnector conexion;
        public Modificar(SQLConnector conec,String condicion)
        {
            InitializeComponent();
            conexion = conec;
        }
    }
}
