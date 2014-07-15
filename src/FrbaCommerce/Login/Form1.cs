using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Registro_de_Usuario;
using System.Security.Cryptography;


namespace FrbaCommerce.Login
{
    public partial class Form1 : Form
    {
        string passHasheada;
        int contadorDeIntentos = 0;
        public Form1()
        {
            InitializeComponent();
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
                int resultado = FrbaCommerce.Login.LoginDatos.logeoSql(txtUsuario.Text, passHasheada);
                switch (resultado)
                {
                    case 0:
                        List<string> rolesDeUsuario = FrbaCommerce.Login.LoginDatos.cantidadDeRoles(txtUsuario.Text);
                        if (rolesDeUsuario.Count() == 1)
                        {
                            Menu_Principal.Form1MenuPrincipal lanzarMenu = new Menu_Principal.Form1MenuPrincipal(rolesDeUsuario.FirstOrDefault());
                            lanzarMenu.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Form2EleccionRol lanzarRoles = new Form2EleccionRol(rolesDeUsuario);
                            lanzarRoles.ShowDialog();
                            this.Close();
                        }
                        break;

                    case 1:
                        contadorDeIntentos += 1;
                        //ACA NO ESTOY TAN DE ACUERDO PARA MI DEBERIA SER PORQUE PUSO MAL LA CONTRASEÑA SOLAMENTE
                        MessageBox.Show("Usuario o Contraseña incorretos\n cantidad de intentos: {0}" + contadorDeIntentos);
                        break;

                    case 2:
                        MessageBox.Show("EL usuario se encuentra inhabilitado");
                        break;

                    case 3:
                        MessageBox.Show("Usuario dado de baja");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Se ha alcanazo el maximo de intentos de login, usuario inhabilitado");
                btnAceptar.Enabled = false;
            }


        }


       public string SHA256Encripta(string input)
            {
                SHA256Managed provider = new SHA256Managed();

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = provider.ComputeHash(inputBytes);

                StringBuilder output = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                    output.Append(hashedBytes[i].ToString("x2").ToLower());

                return output.ToString();
            }

    }
}
