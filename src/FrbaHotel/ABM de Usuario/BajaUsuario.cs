using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class BajaUsuario : Form
    {
        SQLConnector conexion;
        string usuarioId;
        string datosPersId;
        List<TextBox> boxes = new List<TextBox>();
        public BajaUsuario(string[] valores, SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            usuarioId = valores[0];
            datosPersId = valores[1];
            DataTable data = conec.consulta("SELECT Rol_Desc,Hotel_Id FROM NENE_MALLOC.Usuario,NENE_MALLOC.Rol,NENE_MALLOC.Usuario_Por_Rol_Por_Hotel WHERE Usuario.Usuario_Id = Usuario_Por_Rol_Por_Hotel.Usuario_Id AND Rol.Rol_Id = Usuario_Por_Rol_Por_Hotel.Rol_Id AND Usuario.Usuario_Id = '"+usuarioId+"'");
            txtRolAsignado.Text = data.Rows[0].ItemArray[0].ToString();
            txtHotelTrabaja.Text = data.Rows[0].ItemArray[1].ToString();
            
            this.generarBoxes();
            this.cargarBoxes(valores);

        }
        private void generarBoxes()
        {
            boxes.Add(txtUser);
            boxes.Add(txtPass);
            boxes.Add(txtNom);
            boxes.Add(txtApellido);
            boxes.Add(txtTDoc);
            boxes.Add(txtNDoc);
            boxes.Add(txtMail);
            boxes.Add(txtTelefono);
            boxes.Add(txtCalle);
            boxes.Add(txtNcalle);
            boxes.Add(txtPiso);
            boxes.Add(txtDepto);
            boxes.Add(txtFecNac);
        }
        private void cargarBoxes(string[] listaVal)
        {
            int i = 2;
            foreach (var txtB in boxes)
            {
                txtB.Text = listaVal[i];
                i++;
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NENE_MALLOC.Usuario set Usuario_Estado = 1 WHERE Usuario_Id = '"+usuarioId+"'";
            conexion.executeOnly(query);
            MessageBox.Show("Usuario dado de baja con exito");
        }
    }
}
