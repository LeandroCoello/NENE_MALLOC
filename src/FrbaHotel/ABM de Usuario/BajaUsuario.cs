using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class BajaUsuario : Form
    {
        SQLConnector conexion;
        public BajaUsuario(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

    }
}
