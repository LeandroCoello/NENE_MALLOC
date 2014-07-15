using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Sistema;


namespace FrbaCommerce.Login
{
    public partial class Form1 : Form
    {
        string passHasheada;
        int contadorDeIntentos = 0;
        private Inicio inicio;
        public Form1(SQLConnector connection)
        {
            InitializeComponent();
            inicio = new Inicio(connection);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContraseña.Text == "")
            {
                MessageBox.Show("Por favor complete los campos de usuario y contraseña");
                return;
            }


            if (contadorDeIntentos < 3)
            {
                try
                {
                    inicio.login(txtUsuario.Text, txtContraseña.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Se ha alcanazo el maximo de intentos de login, usuario inhabilitado");
                btnAceptar.Enabled = false;
            }


        }
    }
}
