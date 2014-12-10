using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class AgregarConsu : Form
    {
        RegConsumible form;
        SQLConnector conexion;
        public AgregarConsu(RegConsumible consumibleForm,SQLConnector conec)
        {
            InitializeComponent();
            form = consumibleForm;
            conexion = conec;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "" || txtDesc.Text=="") 
            {
                MessageBox.Show("Complete los campos");
            }
            else
            {
                try{
                DataTable consus =conexion.consulta("SELECT Consumible_Desc FROM NENE_MALLOC.Consumible WHERE Consumible_Desc  ="+txtDesc.Text);
                if (consus.Rows.Count >= 1)
                {
                    form.agregarAlGrid(txtDesc.Text, txtCantidad.Text);
                    this.Close();
                }
                }catch{
                    MessageBox.Show("Consumible no encontrado");
                }
            }
        }
    }
}
