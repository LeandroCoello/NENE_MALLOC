using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;
using FrbaCommerce.Sistema.QueryConditions;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Filtrado : Form
    {
        SQLConnector conec = new SQLConnector();
        
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
           
            string queryConsulta = "SELECT C.Cli_Nombre,C.Cli_Apellido,C.Cli_TipoDoc,C.Cli_NroDoc,D.Datos_Mail,C.Cli_Fecha_Nac,D.Datos_Tel,D.Datos_Dom_Calle,D.Datos_Nro_Calle,D.Datos_Dom_Piso,D.Datos_Depto,D.Datos_Cod_Postal,D.Datos_Localidad FROM SQL_O.Cliente C,SQL_O.Datos_Pers"
                                    + "WHERE C.Cli_Datos_Pers = D._Datos_Id"
                                    + this.generarConsultas( this.validarConsultas())
                                    + "GROUP BY C.Cli_Nombre,C.Cli_Apellido,C.Cli_TipoDoc,C.Cli_NroDoc,C.Cli_Mail";
            dataGridView1.DataSource = conec.consulta(queryConsulta);
        }

        private string generarConsultas(List<String> consultas) {
            List<Regla> listaDeReglas = consultas.ConvertAll(p=> new Regla(p));
            if (listaDeReglas.Count() > 0)
            {
                Condition regla = listaDeReglas[0];
                listaDeReglas.Remove((Regla) regla);
                foreach (Regla unaRegla in listaDeReglas)
                {
                    regla = new And(regla, unaRegla);
                }
                return regla.toString();
            }
            else
            {
                return null;
            }


         }
        private List<string> validarConsultas(){
            List<string> consultas = new List<string>();
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
            string DNI = dataGridView1.SelectedCells[0].Value.ToString();
            string queryUser = "SELECT U.username FROM SQL_O.Usuario U,SQL_O.Cliente C,SQL_O.Tipo T"
                                +"WHERE C.Cli_Id = T.Tipo_Cod and"
                                +"T.Tipo_Cod = U.User_Tipo and"
                                +"C.Cli_NroDoc ="+DNI
                                +"GROUP BY U.username";

            string userId= conec.consulta(queryUser).ToString();
            List<string> valores = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                valores.Add(row.ToString());
            }
            Modificar levantarModif = new Modificar(valores,userId);
            levantarModif.ShowDialog();
            this.Hide();

        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

        }
        
        }
    }

