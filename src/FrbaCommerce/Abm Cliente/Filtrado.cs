using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Filtrado : Form
    {
     
        public Filtrado()
        {

            InitializeComponent();
            cBTipDoc.Items.Add("DNI");
            cBTipDoc.Items.Add("CI");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtMail.Clear();
            txtNDoc.Clear();
            txtNombre.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string queryConsulta = "SELECT C.Cli_Nombre,C.Cli_Apellido,C.Cli_TipoDoc,C.Cli_NroDoc,C.Cli_Mail FROM SQL_O.Cliente C"
                                    +"WHERE ";
        }
        }
    }
}
