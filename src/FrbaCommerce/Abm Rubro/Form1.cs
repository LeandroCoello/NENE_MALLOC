using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Rubro
{
    public partial class Form1 : Form
    {
        int codigo;
        string descripcion;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            this.txtCodigo.Focus();
            codigo = int.Parse(this.txtCodigo.Text);
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            this.txtDescripcion.Focus();
            descripcion = this.txtCodigo.Text;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            //Enviar Al sql el nuevo rubro creado
            lblAvisaCreacion.Text = "Rubro creado exitosamente";
        }

    }
}
