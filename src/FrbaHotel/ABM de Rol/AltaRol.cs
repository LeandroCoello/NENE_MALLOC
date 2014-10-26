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
    public partial class AltaRol : Form
    {
        SQLConnector conexion = new SQLConnector();
        public AltaRol()
        {
            InitializeComponent();
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            string query = "exec NENE_MALLOC.alta_rol ()";
        }

    }
}
