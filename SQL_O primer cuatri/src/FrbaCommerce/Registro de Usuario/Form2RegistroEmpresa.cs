﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Form2RegistroEmpresa : Form
    {
        string rolAsignado;
        public Form2RegistroEmpresa()
        {
            InitializeComponent();
       }

        private void btnFinalizarYContinuar_Click(object sender, EventArgs e)
        {
            //Enviar TODOS LOS DATOS AL SQL los valida y devuelve
            //si todo ok enviar al menu principal
            //sino avisar error y que cambie el campo
            Menu_Principal.Form1MenuPrincipal levantarMenu = new Menu_Principal.Form1MenuPrincipal(rolAsignado);
            levantarMenu.ShowDialog();
            this.Close();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
