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
        string usuarioId;
        string datosPersId;
        public BajaUsuario(string[] valores, SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            usuarioId = valores[0];
            datosPersId = valores[7];
        }

    }
}
