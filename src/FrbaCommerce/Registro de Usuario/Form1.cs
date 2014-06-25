using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            btnContinuar.Enabled = false;
            LBEleccionDeRol.Items.Add("Cliente");
            LBEleccionDeRol.Items.Add("Empresa");
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void LBEleccionDeRol_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            //Solicitar al sql usuario y contraseña
            btnContinuar.Enabled = true;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
        if(LBEleccionDeRol.SelectedIndex != -1){
            string selected = LBEleccionDeRol.SelectedItem.ToString();
            switch (selected)
            {
                case "Cliente":
                    this.Hide();
                    Form2RegistroCliente registrarCliente = new Form2RegistroCliente();
                    registrarCliente.ShowDialog();
                    break;
                case "Empresa":
                    this.Hide();
                    Form2RegistroEmpresa registrarEmpresa = new Form2RegistroEmpresa();
                    registrarEmpresa.ShowDialog();
                    break;
            }
            }
        else{ MessageBox.Show("Por favor primero seleccione un item");
            }
            
        }


    }

}
