using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class AltaUsuario : Form
    {
        Administrador admin;
        Inicio inicio;
        SQLConnector conec;
        List<TextBox> txtBoxes = new List<TextBox>();
        public AltaUsuario()
        {
            InitializeComponent();
            txtBoxes.Add(txtUser);
            txtBoxes.Add(txtPass);
            txtBoxes.Add(txtNom);
            txtBoxes.Add(txtApellido);
            txtBoxes.Add(txtTDoc);
            txtBoxes.Add(txtNDoc);
            txtBoxes.Add(txtMail);
            txtBoxes.Add(txtTelefono);
            txtBoxes.Add(txtCalle);
            txtBoxes.Add(txtNcalle);
            txtBoxes.Add(txtFecNac);
            txtBoxes.Add(txtHotelTrabaja);
            List<string> rolesActuales = admin.rolesSistema();
            BindingSource bs = new BindingSource();
            bs.DataSource = rolesActuales;
            cBRolesAAsignar.DataSource = bs;
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            foreach (TextBox texto in txtBoxes){
                texto.Text = "";        
                }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (this.estanTodosCompletos()) {
                string passFinal = inicio.SHA256Encripta(txtPass.Text);
                string queryAlta = "exec NENE_MALLOC.Alta_Usuario '"+txtUser.Text+"' '"+passFinal+"' '"+cBRolesAAsignar.SelectedItem.ToString()+"' '"+
                    txtNom.Text+"' '"+txtApellido.Text+"' '"+txtTelefono.Text+"' '"+txtTDoc.Text+"' '"+txtNDoc.Text+"' '"+txtMail.Text+"' '"
                    +txtCalle.Text+"' '"+txtNcalle.Text+"' '"+txtPiso.Text+"' '"+txtDepto.Text+"' '"+txtFecNac.Text+"' '"+txtHotelTrabaja.Text+ "'";
                conec.executeOnly(queryAlta);/*ESTO VAMOS A TENER Q CAMBIARLO PORQ LA QUERY PUEDE DEVOLVERNOS UN ERROR*/
                MessageBox.Show("Usuario creado con exito");
                this.Close();
            }
        }
        private Boolean estanTodosCompletos() {
            foreach (TextBox texto in txtBoxes) { 
                if(String.IsNullOrEmpty(texto.Text)){
                    MessageBox.Show("Por favor complete todos los campos");
                    return false;
                }
            }
            if (String.IsNullOrEmpty(cBRolesAAsignar.SelectedText)) { 
                return false; 
            }
            return true;
        }

    }
}
