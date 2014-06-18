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
        
        string usuarioNombre;
        string passHasheada;
        int contadorDeIntentos = 0;
        public Form1()
        {
            InitializeComponent();
            this.LBRolesElegir.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {   
            if(contadorDeIntentos < 3){
                //enviarle al sql el usuarioNombre y pass para que verificar que sean correctos
                if (usuarioNombre == "retornoSQL" && passHasheada == "passDeSql")
                {
                //Mostrarse los roles que posee y dps se conecta, si tiene uno solo entra directo al sistema por ese rol
                 LBRolesElegir.Visible = true;
                }
                else {//salta cartel de error por: gato no existis registrate primero 
                    lblConfirmacionLog.Text = "Usuario o Contraseña incorrectos por favor pruebe nuevamente";
                    contadorDeIntentos += 1;
                }
            }
            
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.Focus();
            passHasheada = this.SHA256Encripta(txtContraseña.Text);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            this.txtContraseña.Focus();
            usuarioNombre = this.txtUsuario.Text;
        }

        private void lblConfirmacionLog_Click(object sender, EventArgs e)
        {}

        private void btnAcceso_Sistema_Click(object sender, EventArgs e)
        {
            //levanta la form acorde al rol elegido
        }

        private void LBRolesElegir_SelectedIndexChanged(object sender, EventArgs e)
        {}


       public string SHA256Encripta(string input)
            {
                SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = provider.ComputeHash(inputBytes);

                StringBuilder output = new StringBuilder();

                for (int i = 0; i < hashedBytes.Length; i++)
                    output.Append(hashedBytes[i].ToString("x2").ToLower());

                return output.ToString();
            }

    }
}
