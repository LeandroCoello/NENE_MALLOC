using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class AltaRol : Form
    {
        SQLConnector conexion;
        public AltaRol(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            DataTable funcionalidades = conec.consulta("");
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            if (hayVacios())
            {
                MessageBox.Show("Por favor complete todos los campos");
            }
            else
            {
                string query = "INSERT INTO NENE_MALLOC.Rol VALUES ('" + txtNomRol.Text + "','" + cBFuncio.SelectedItem.ToString() + "', " + txtEstado.Text + ")";
                try
                {
                    conexion.executeOnly(query);
                    MessageBox.Show("Rol creado con exito");
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            
        }
        private Boolean hayVacios() 
        {
            if (string.IsNullOrEmpty(txtNomRol.Text) || string.IsNullOrEmpty(cBFuncio.SelectedItem.ToString()) || string.IsNullOrEmpty(txtEstado.Text))
            {
                return true;
            }
            else { 
                return false; 
            }

        }
    }
}
