using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Form2ParaCliente : Form
    {
        string nombre;
        string apellido;
        string nroDoc;
        string tipoDeDoc;
        string mail;
        string telefono;
        string direccion;
        string localidad;
        string codigoPostal;
        string fecNac;
        string cuil;

        public Form2ParaCliente()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.txtNombre.Focus();
            nombre = this.txtNombre.Text;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            this.txtApellido.Focus();
            apellido = this.txtApellido.Text;
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            this.txtNroDoc.Focus();
            nroDoc = this.txtNroDoc.Text;
        }

        private void txtTipDoc_TextChanged(object sender, EventArgs e)
        {
            this.txtTipDoc.Focus();
            tipoDeDoc = this.txtTipDoc.Text;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            this.txtMail.Focus();
            mail = this.txtMail.Text;
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            this.txtTel.Focus();
            telefono = this.txtTel.Text;
        }

        private void txtDirec_TextChanged(object sender, EventArgs e)
        {
            this.txtDirec.Focus();
            direccion = this.txtDirec.Text;
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            this.txtLocalidad.Focus();
            localidad = this.txtLocalidad.Text;
        }

        private void txtCodPost_TextChanged(object sender, EventArgs e)
        {
            this.txtCodPost.Focus();
            codigoPostal = this.txtCodPost.Text;

        }

        private void txtFecNac_TextChanged(object sender, EventArgs e)
        {
            this.txtFecNac.Focus();
            fecNac = this.txtFecNac.Text;
        }

        private void txtCuil_TextChanged(object sender, EventArgs e)
        {
            this.txtCuil.Focus();
            cuil = this.txtCuil.Text;
        }

        private void btnFinalizayConfirma_Click(object sender, EventArgs e)
        {
            //Mandarle los datos al sql para que los cargue y enviarlo a su respectiva Abm (ingresa al sistema)
        }








    }
}
