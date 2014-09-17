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
    public partial class BAJA : Form
    {
        SQLConnector conec = new SQLConnector();
        public BAJA(List<string> valores)
        {
            InitializeComponent();
            textBox1.Text = valores[0];
            textBox2.Text = valores[1];
            textBox3.Text = valores[2];
            textBox4.Text = valores[3];
            textBox5.Text = valores[4];
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            string queryBaja = "exec SQL_O.baja_cliente '" + textBox1.Text + "'" + "'" + textBox2.Text + "'" + "'" + textBox3.Text + "'" + "'" + textBox4.Text + "'" + "'" + textBox5.Text + "'";
            conec.executeOnly(queryBaja);
            MessageBox.Show("Cliente dado de baja");
            this.Close();
        }
    }
}
