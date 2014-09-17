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
    
    public partial class Baja : Form
    {
        SQLConnector conec = new SQLConnector();
        public Baja(List<string> valores) 
        {
            InitializeComponent();
            textBox1.Text = valores[0].ToString();
            textBox2.Text = valores[1].ToString();
            textBox3.Text = valores[2].ToString();
            textBox4.Text = valores[3].ToString();
            textBox5.Text = valores[4].ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string queryBaja = "exec SQL_O.baja_visibilidad '" + textBox2.Text + "'";
            conec.executeOnly(queryBaja);
        }
    }
}
