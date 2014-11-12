using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;


namespace FrbaHotel.ABM_de_Hotel
{
    public partial class ABMHotel : Form
    {
        SQLConnector conexion;
        public ABMHotel(SQLConnector coneccion)
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }
    }
}
