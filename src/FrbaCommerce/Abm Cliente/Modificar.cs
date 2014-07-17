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
    public partial class Modificar : Form
    {
        string user;
        SQLConnector conec = new SQLConnector();
        public Modificar(List<string> camposAllenar,string valorId )
        {
            InitializeComponent();
            textBox1.Text = camposAllenar[0];
            textBox2.Text = camposAllenar[1];
            textBox3.Text = camposAllenar[2];
            textBox4.Text = camposAllenar[3];
            textBox5.Text = camposAllenar[4];
            textBox6.Text = camposAllenar[5];
            textBox7.Text = camposAllenar[6];
            textBox8.Text = camposAllenar[7];
            textBox9.Text = camposAllenar[8];
            textBox10.Text = camposAllenar[9];
            textBox11.Text = camposAllenar[10];
            textBox12.Text = camposAllenar[11];
            textBox13.Text = camposAllenar[12];
            user = valorId;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string queryModificar = "exec SQL_O.modificacion_cliente '" + textBox1.Text + "'" + "'" + textBox2.Text + "'" + "'" + textBox3.Text + "'" + "'" + textBox4.Text + "'" + "'" + textBox5.Text + "'"
                 + textBox6.Text + "'" + "'" + textBox7.Text + "'" + textBox8.Text + "'" + "'" + textBox9.Text + "'" + textBox10.Text + "'" + "'" + textBox11.Text + "'" + textBox12.Text + "'" + "'" + textBox13.Text + "'" + user + "'";
            int valorConsulta = conec.executeIntegerProcedure(queryModificar);
            switch (valorConsulta) { 
                case 1:
                    MessageBox.Show("El tipo y numero de documento ya pertenece a otro cliente");
                    break;
                case 2:
                    MessageBox.Show("El numero de cuil ya pertenece a otro cliente");
                    break;
                case 3:
                    MessageBox.Show("El numero de telefono ya pertenece a otro cliente");
                    break;
                default:
                    MessageBox.Show("Cliente modificado satisfactoriamente");
                    this.Close();
                    break;

            }
        }
    }
}
