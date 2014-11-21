using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ModificarRol : Form
    {
        SQLConnector conexion;
        public ModificarRol(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {

        }
    }
}
