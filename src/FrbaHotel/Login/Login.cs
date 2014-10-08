using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;




namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        string passHasheada;
        int contadorDeIntentos = 0;
        private Inicio inicio;
        private UsuarioLogueado userLog;
        private List<string> roles = new List<string>();
        public Login(/*SQLConnector connection*/)
        {
            InitializeComponent();
            /*inicio = new Inicio(connection);*/
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
                   userLog =  inicio.login(txtUsuario.Text, txtContraseña.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
               roles = userLog.conseguirRoles();
                     if (roles.Count() > 1)
                         {
                           EleccionRol levantarEleccionRol = new EleccionRol();
                         }
                     else {
                         Menu_Principal.MenuPrincipal levantarMenu = new FrbaHotel.Menu_Principal.MenuPrincipal();
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
