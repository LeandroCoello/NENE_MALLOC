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
    public partial class Form2ContinuacionRegistro : Form
    {
        string rolAsignado;
        string nombre;
        string apellido;
        int nroDoc;
        string tipoDeDoc;
        string telefono;
        string razonSocial;
        string mail;
        string direccion;
        string localidad;
        string codigoPostal;
        string ciudad;
        int cuit;
        string nombreDeContacto;
        string fechaCreacion;

        public Form2ContinuacionRegistro(string rolElegido)
        {
            InitializeComponent();
            if (rolElegido == "Cliente") { this.levantarFormlarioCliente(); } else { this.levantarFormularioEmpresa(); }
            rolAsignado = rolElegido;
        }
        public void levantarFormlarioCliente() {
            txtApellido.Visible = true;
            lblApellido.Visible = true;
            txtNombre.Visible = true;
            lblNombre.Visible = true;
            txtNroDoc.Visible = true;
            lblNDeDoc.Visible = true;
            txtTipDoc.Visible = true;
            lblTdeDoc.Visible = true;
            lblCuit.Text = "Cuil:";
            lblFecCreac.Text = "Fecha De Nacimiento:";
       }

        public void levantarFormularioEmpresa()
        {
            txtRazonSocial.Visible = true;
            lblRazonSocial.Visible = true;
            txtCuit.Visible = true;
            lblCuit.Visible = true;
            txtNomContacto.Visible = true;
            lblNomCont.Visible = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Focus();
            nombre = txtNombre.Text;
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            txtApellido.Focus();
            apellido = txtApellido.Text;
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            txtNroDoc.Focus();
            nroDoc = int.Parse(this.txtNroDoc.Text);
        }

        private void txtTipDoc_TextChanged(object sender, EventArgs e)
        {
            txtTipDoc.Focus();
            tipoDeDoc = txtTipDoc.Text;
        }




        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            txtRazonSocial.Focus();
            razonSocial = txtRazonSocial.Text;
        }



        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            txtCodigoPostal.Focus();
            codigoPostal = txtCodigoPostal.Text;
        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {
            txtCiudad.Focus();
            ciudad = txtCiudad.Text;
        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {
            txtCuit.Focus();
            cuit = int.Parse(this.txtCuit.Text);
        }

        private void txtFecCreac_TextChanged(object sender, EventArgs e)
        {
            txtFecCreac.Focus();
            fechaCreacion = txtFecCreac.Text;
        }
 

        private void txtNomContacto_TextChanged(object sender, EventArgs e)
        {
            txtNomContacto.Focus();
            nombreDeContacto = txtNomContacto.Text;
        }


        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            txtMail.Focus();
            mail = txtMail.Text;
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            txtTelefono.Focus();
            telefono = txtTelefono.Text;
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            txtDireccion.Focus();
            direccion = txtDireccion.Text;
        }

        private void txtLocalidad_TextChanged(object sender, EventArgs e)
        {
            txtLocalidad.Focus();
            localidad = txtLocalidad.Text;
        }
        private void btnFinalizarYContinuar_Click(object sender, EventArgs e)
        {
            //Enviar TODOS LOS DATOS AL SQL los valida y devuelve
            //si todo ok enviar al menu principal
            //sino avisar error y que cambie el campo
            Menu_Principal.Form1MenuPrincipal levantarMenu = new Menu_Principal.Form1MenuPrincipal(rolAsignado);
            levantarMenu.ShowDialog();
            this.Close();
        }





  
    }
}
