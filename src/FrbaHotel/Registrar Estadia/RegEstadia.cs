using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Registrar_Estadia
{
    public partial class RegEstadia : Form
    {
        UsuarioLogueado usuario;
        public RegEstadia(UsuarioLogueado userLog)
        {
            InitializeComponent();
            usuario = userLog;
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            Ingreso_Egreso levantarCheck = new Ingreso_Egreso(usuario);
            levantarCheck.ShowDialog();
            this.Hide();

        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            Ingreso_Egreso levantarOUT = new Ingreso_Egreso(usuario);
            levantarOUT.configurarOUT();
            levantarOUT.ShowDialog();
            this.Hide();
        }
    }
}
