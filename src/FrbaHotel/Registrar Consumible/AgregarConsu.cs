using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class AgregarConsu : Form
    {
        RegConsumible form;
        public AgregarConsu(RegConsumible consumibleForm)
        {
            InitializeComponent();
            form = consumibleForm;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "" || txtDesc.Text=="") 
            {
                MessageBox.Show("Complete los campos");
            }
            else
            {
                form.agregarAlGrid(txtDesc.Text, txtCantidad.Text);
                this.Close();
            }
        }
    }
}
