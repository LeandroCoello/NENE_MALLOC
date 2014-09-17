using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Login;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.Sistema;


namespace FrbaCommerce
{
    public partial class PrincipalForm : Form
    {
        private SQLConnector connection;
        public PrincipalForm()
        {

            InitializeComponent();
            connection = new SQLConnector();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrbaCommerce.Login.LoginForm logearse = new FrbaCommerce.Login.LoginForm(connection);
            this.Hide();
            logearse.ShowDialog();
            this.Show();
            
        }

        private void btnRegistracion_Click(object sender, EventArgs e)
        {
            FrbaCommerce.Registro_de_Usuario.RegistroUsuarioForm registracion = new FrbaCommerce.Registro_de_Usuario.RegistroUsuarioForm();
            this.Hide();
            registracion.ShowDialog();
            FrbaCommerce.Login.LoginForm logearse = new FrbaCommerce.Login.LoginForm(connection);
            this.Show();
            
        }
    }

}
