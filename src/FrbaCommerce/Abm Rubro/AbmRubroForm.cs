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
    public partial class AbmRubroForm : Form
    {
        int codigo;
        string descripcion;

        public AbmRubroForm()
        {
            InitializeComponent();
            txtCodigo.Visible = false;
            txtDescripcion.Visible = false;
            lblCodigo.Visible = false;
            lblDescrip.Visible = false;
            
            
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
            txtCodigo.Visible = true;
            txtDescripcion.Visible = true;
            lblCodigo.Visible = true;
            lblDescrip.Visible = true;
            lblAvisaCreacion.Text = "Rubro creado exitosamente";
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void btnListo_Click(object sender, EventArgs e)
        {
            //Enviar al sql si se creo q agregue el rubro, si se modifico el cambio o si elimina que borre el rubro
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtCodigo.Visible = true;
            txtDescripcion.Visible = true;
            lblCodigo.Visible = true;
            lblDescrip.Visible = true;
            //Perdile al sql todos los rubros disponibles y cagarlos en la listBox

            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Misma logica que el de modificar, solo que ademas se avisa al sql que borre de la lista
        }

    }
}
