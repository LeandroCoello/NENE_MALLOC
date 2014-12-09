using System;
using System.Configuration;
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
        SQLConnector conexion;
        public AltaCliente(SQLConnector conec)
        {
            InitializeComponent();
            txtBoxes.Add(txtNom);
            txtBoxes.Add(txtApellido);
            txtBoxes.Add(txtTipoDoc);
            txtBoxes.Add(txtNroDoc);
            txtBoxes.Add(txtMail);
            txtBoxes.Add(txtDireccion);
            txtBoxes.Add(txtNroCalle);
            txtBoxes.Add(txtNacionalidad);
            dateTimePicker1.Value = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]);
            conexion = conec;
            
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (var texto in txtBoxes) {
                if (String.IsNullOrEmpty(texto.Text)) {
                    MessageBox.Show("Complete todos los campos");
                    break;
                }
            }
            string queryCliente = " declare @Id numeric(1,0) exec NENE_MALLOC.alta_cliente '" + txtNom.Text + "','" + txtApellido.Text + "'," + txtTelefono.Text + ",'"
                +txtTipoDoc.Text+"',"+txtNroDoc.Text+",'"+txtMail.Text+"','"+txtDireccion.Text+"',"+txtNroCalle.Text+","+txtPiso.Text+",'"+txtDepto.Text+"','"+dateTimePicker1.Value.ToString("yyyyMMdd")+"','"+txtNacionalidad.Text+"',@Id  SELECT @Id";
            try
            {
                DataTable clienteId = conexion.consulta(queryCliente);
                MessageBox.Show("Cliente registrado con exito ID:"+clienteId.Rows[0].ItemArray[0].ToString());
                this.Close();
            }
            catch(Exception excep) 
            {
                MessageBox.Show(excep.Message);
            }
        }    /*inicioDateTimePicker1.Value.ToString("yyyyMMdd")*/
    }
}
