using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class RegConsumible : Form
    {
        SQLConnector conexion;
        public RegConsumible(SQLConnector conecc)
        {
            InitializeComponent();
            conexion = conecc;
        }
    }
}
