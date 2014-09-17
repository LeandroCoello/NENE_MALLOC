using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Modificar : Form
    {
        SQLConnector conec = new SQLConnector();
        public Modificar(List<string> valores)
        {
            InitializeComponent();
            textBox1.Text = valores[0].ToString();
            textBox2.Text = valores[1].ToString();
            textBox3.Text = valores[2].ToString();
            textBox4.Text = valores[3].ToString();
            textBox5.Text = valores[4].ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string queryModificar = "exec SQL_O.modificacion_visibilidad '" + textBox1.Text + "'" + "'" + textBox2.Text + "'" + "'" + textBox3.Text + "'" + "'" + textBox4.Text + "'" + "'" + textBox5.Text + "'";
            int unValor = conec.executeIntegerProcedure(queryModificar);
            if (unValor == 1)
            {
                MessageBox.Show("La descripción de esa visibilidad ya existe");
            }
            else {
                MessageBox.Show("Modificación realizada con exito");
            }
          }
        }
    }

