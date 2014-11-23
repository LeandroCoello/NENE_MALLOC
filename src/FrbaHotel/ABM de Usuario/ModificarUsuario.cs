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
    public partial class ModificarUsuario : Form
    {
        Administrador admin;
        SQLConnector conexion;
        List<TextBox> boxes = new List<TextBox>();
        string usuarioId;
        string datosPersId;
        public ModificarUsuario(string[] valores,SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            admin = new Administrador(conec);
            List<string> rolesActuales = admin.rolesSistema();
            foreach (var rol in rolesActuales) {
                cBRolesAAsignar.Items.Add(rol);
            }
            usuarioId = valores[0];
            datosPersId = valores[1];
            this.generarBoxes();
            this.cargarBoxes(valores);
        }
        private void generarBoxes() {
            boxes.Add(txtUser);
            boxes.Add(txtPass);
            boxes.Add(txtNom);
            boxes.Add(txtApellido);
            boxes.Add(txtTDoc);
            boxes.Add(txtNDoc);
            boxes.Add(txtMail);
            boxes.Add(txtTelefono);
            boxes.Add(txtCalle);
            boxes.Add(txtNcalle);
            boxes.Add(txtPiso);
            boxes.Add(txtDepto);
            boxes.Add(txtFecNac);
        }
        private void cargarBoxes(string[] listaVal)
        {
            int i = 2;        
            foreach(var txtB in boxes)
            {
                txtB.Text = listaVal[i];
                i++;
            }
        }

        private void btnModUser_Click(object sender, EventArgs e)
        {
            if (boxes.Where(b => string.IsNullOrEmpty(b.Text)).Any() || string.IsNullOrEmpty(txtHotelTrabaja.Text) || cBRolesAAsignar.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todo los campos");
            }
            else
            {
                string query = "EXEC NENE_MALLOC.modificacion_usuario '" + txtUser.Text + "','" + txtPass.Text + "','" + txtNom.Text + "','" + txtApellido.Text +
                    "'," + txtTelefono.Text + ",'" + txtTDoc.Text + "'," + txtNDoc.Text + ",'" + txtMail.Text + "','" + txtCalle.Text + "'," + txtNcalle.Text + "," + txtPiso.Text
                    + ",'" + txtDepto.Text + "','" + txtFecNac.Text + "," + txtHotelTrabaja.Text + "," + usuarioId;
                conexion.executeOnly(query);
                MessageBox.Show("Usuario modificado con exito");
                this.Close();
            }
        }


    }
}
