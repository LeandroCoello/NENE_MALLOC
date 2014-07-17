using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Modificar : Form
    {
        public Modificar(List<string> camposAllenar )
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
        }
    }
}
