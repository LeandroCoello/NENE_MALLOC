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
    public partial class Filtrado : Form
    {
        SQLConnector conec = new SQLConnector();
        List<string> consultas = new List<string>();
        public Filtrado()
        {

            InitializeComponent();
            cBTipDoc.Items.Add("DNI");
            cBTipDoc.Items.Add("CI");
            cBTipDoc.Items.Add("");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtApellido.Clear();
            txtMail.Clear();
            txtNDoc.Clear();
            txtNombre.Clear();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.validarConsultas();
            string queryConsulta = "SELECT C.Cli_Nombre,C.Cli_Apellido,C.Cli_TipoDoc,C.Cli_NroDoc,D.Datos_Mail,C.Cli_Fecha_Nac,D.Datos_Tel,D.Datos_Dom_Calle,D.Datos_Nro_Calle,D.Datos_Dom_Piso,D.Datos_Depto,D.Datos_Cod_Postal,D.Datos_Localidad FROM SQL_O.Cliente C,SQL_O.Datos_Pers"
                                    + "WHERE C.Cli_Datos_Pers = D._Datos_Id"
                                    + this.generarConsultas()
                                    + "GROUP BY C.Cli_Nombre,C.Cli_Apellido,C.Cli_TipoDoc,C.Cli_NroDoc,C.Cli_Mail";
            dataGridView1.DataSource = conec.consulta(queryConsulta);
        }

        private string generarConsultas() {
            string consulta="";
            string generador;
            bool val = true;
            int i = 0;
            while (val) {
                if (string.IsNullOrEmpty(consultas[i]))
                {
                    val = false;
                }
                else { consulta = "and"+consulta+ consultas[i]; }
               
                if (!string.IsNullOrEmpty(consultas[i+1])){
                    consulta += " and ";
                }
                i++;
           }
            if (string.IsNullOrEmpty(consulta)) {
                return generador = "";
            }
            else { return generador = "WHERE" + consulta; }
        }
        private List<string> validarConsultas(){
            if(!string.IsNullOrEmpty(txtNombre.Text)){
                    consultas.Add( "C.Cli_Nombre LIKE%" + txtNombre.Text+"%");
                }
            if(!string.IsNullOrEmpty(txtApellido.Text)){
                    consultas.Add( "C.Cli_Apellido LIKE%" + txtApellido.Text+"%");
                }
            if(!string.IsNullOrEmpty(txtNDoc.Text)){
                    consultas.Add( "C.Cli_Nombre LIKE%" + txtNombre.Text+"%");
                }
            if(!string.IsNullOrEmpty(txtMail.Text)){
                    consultas.Add( "C.Cli_Mail LIKE%" + txtNombre.Text+"%");
                }
            if(!string.IsNullOrEmpty(cBTipDoc.SelectedItem.ToString())){
                    consultas.Add( "C.Cli_Nombre =" + cBTipDoc.SelectedItem.ToString());
                }
            return consultas;
         }

        private void btnModif_Click(object sender, EventArgs e)
        {
            List<string> valores = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                valores.Add(row.ToString());
            }
            Modificar levantarModif = new Modificar(valores);
            levantarModif.ShowDialog();
            this.Hide();

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }
        
        }
    }

