using System;
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
        SQLConnector conexion;
        public FacturarPublicaciones(SQLConnector conecc)
        {
            InitializeComponent();
            conexion = conecc;
        }
    }
}
