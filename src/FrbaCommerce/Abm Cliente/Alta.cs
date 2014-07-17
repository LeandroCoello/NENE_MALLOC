using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Alta : Form
    {
        SQLConnector conec = new SQLConnector();
        Inicio inicio;
        public Alta()
        {
            InitializeComponent();
            cbTipoDoc.Items.Add("DNI");
            cbTipoDoc.Items.Add("CI");
        }

        private void btnDarAlta_Click(object sender, EventArgs e)
        {
            string nombreUsuario = inicio.registrarse().getNombreUsuario();
            string queryAlta = "exec SQL_O.alta_cliente '" + txtNDoc.Text + "'" + "'" + cbTipoDoc.SelectedItem.ToString() + "'" + "'" + txtApellido.Text + "'" + "'" + txtNombre.Text + "'"
                                + "'" + "'" + txtCuil.Text + "'" + "'" + txtFecNac + "'" + "'" + txtMail.Text + "'" + "'" + txtTelefono.Text + "'"
                                + "'" + "'" + txtCalle.Text + "'" + "'" + txtNroCalle.Text + "'" + "'" + "'" + txtPiso.Text + "'" + "'" + txtDepto.Text+ "'"
                                + "'" + "'" + txtCodPost.Text + "'" + "'" + nombreUsuario + "'" + "'" + "'" + txtLocal.Text + "'";
            int valor = conec.executeIntegerProcedure(queryAlta);
            switch (valor) { 
                case 1:
                    MessageBox.Show("EL DNI YA EXISTE");
                break;
                case 2:
                    MessageBox.Show("EL CUIL YA EXISTE");
                break;
                case 3:
                    MessageBox.Show("EL NRO DE TELEFONO INGRESADO YA EXISTE");
                break;
                default:
                    MessageBox.Show("Cliente creado satisfactoriamente");
                break;
            }
            this.Close();
        }
    }
}
