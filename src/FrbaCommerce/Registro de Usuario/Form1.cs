using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Form1 : Form
    {
        string nombreUsuario;
        string contraseñaUsuario;
        string contraseñaHasheada;
        Encriptador encriptar = new Encriptador();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LBEleccionDeRol.Items.Add("Cliente");
            this.LBEleccionDeRol.Items.Add("Empresa");
            this.LBEleccionDeRol.Items.Add("Administrador");
        }

        private void txtIngresoDeUsuario_TextChanged(object sender, EventArgs e)
        {
            this.txtIngresoDeUsuario.Focus();
            nombreUsuario = this.txtIngresoDeUsuario.Text;
        }

        private void txtIngreDeContraseña_TextChanged(object sender, EventArgs e)
        {
            this.txtIngreDeContraseña.Focus();
            contraseñaUsuario = this.txtIngreDeContraseña.Text;
            contraseñaHasheada = encriptar.SHA256Encripta(contraseñaUsuario);
        }

        private void LBEleccionDeRol_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            //Consultamos al SQL_O las siguiente validaciones:
            //si ya existe el usuario con ese rol, tiene que elejir otro
            //si el rol q tiene asignado es empresa y quiere registrarse como cliente error
            //queres validar tambien q alla escrito en los campos ? me parece programacion APB pero bueno como quieras
            //si esta todo ok, hace click en siguiente donde aparece una subForm dependiendo del rol para que cargue 
            //el resto de los datos
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            btnContinuar.Enabled = false;
        }


    }
    public class Encriptador
    {
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
