using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Login
{
    public partial class Form1 : Form
    {
        string usuarioNombre;
        string contraseña;
        string passHasheada;
        int contadorDeIntentos = 0;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {   
            if(contadorDeIntentos < 3){
                //enviarle al sql el usuarioNombre y pass para que verificar que sean correctos
                if (usuarioNombre == "retornoSQL" && passHasheada == "passDeSql")
                {
                //Mostrarse los roles que posee y dps se conecta, si tiene uno solo entra directo al sistema por ese rol
                }
                else {//salta cartel de error por: gato no existis registrate primero 
                    lblConfirmacionLog.Text = "Nombre o Usuario incorrectos por favor pruebe nuevamente";
                    contadorDeIntentos += 1;
                }
            }
            
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            this.txtContraseña.Focus();
            contraseña = this.txtContraseña.Text;
            Registro_de_Usuario.Encriptador encriptador = new Registro_de_Usuario.Encriptador();
            passHasheada = encriptador.SHA256Encripta(contraseña);
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


    }
}
