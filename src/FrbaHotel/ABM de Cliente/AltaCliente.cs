using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class AltaCliente : Form
    {
        List<TextBox> txtBoxes = new List<TextBox>();
        
        public AltaCliente()
        {
            InitializeComponent();
            txtBoxes.Add(txtNom);
            txtBoxes.Add(txtApellido);
            txtBoxes.Add(txtTipoDoc);
            txtBoxes.Add(txtNroDoc);
            txtBoxes.Add(txtMail);
            txtBoxes.Add(txtDireccion);
            txtBoxes.Add(txtNroCalle);
            txtBoxes.Add(txtFecNac);
            txtBoxes.Add(txtNacionalidad);
            
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (var texto in txtBoxes) {
                if (String.IsNullOrEmpty(texto.Text)) {
                    MessageBox.Show("Complete todos los campos");
                    break;
                }
            }
            SQLConnector conec = new SQLConnector();
            string queryCliente = "exec NENE_MALLOC.alta_cliente '"+txtNom.Text+"' '"+txtApellido.Text+"' '"+txtTelefono.Text+"' '"
                +txtTipoDoc.Text+"' '"+txtNroDoc.Text+"' '"+txtMail.Text+"' '"+txtDireccion.Text+"' '"+txtNroCalle.Text+"' '"+txtPiso.Text+"' '"+txtDepto+"' '"
                +txtFecNac+"' '"+txtNacionalidad+"'";
            conec.executeOnly(queryCliente);/*REVISAR COMO ATRAPAR ERRORES DE SQL*/
            MessageBox.Show("Cliente registrado con exito");
        }
    }
}
