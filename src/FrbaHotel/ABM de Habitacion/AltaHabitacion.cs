using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class HabitacionAlta : Form
    {
        SQLConnector conexion;
        public HabitacionAlta(SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            DataTable tiposHab = conexion.consulta("SELECT Habitacion_Tipo FROM NENE_MALLOC.Habitacion GROUP BY Habitacion_Tipo");
            foreach(DataRow dr in tiposHab.Rows){
                cBTipoHabitacion.Items.Add(dr["Habitacion_Tipo"].ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConVista.Text) || string.IsNullOrEmpty(txtDesc.Text) || string.IsNullOrEmpty(txtNroHabi.Text) || string.IsNullOrEmpty(txtPisoHotel.Text)
                || string.IsNullOrEmpty(cBTipoHabitacion.SelectedItem.ToString())|| string.IsNullOrEmpty(txtHotel.Text))
            {
                MessageBox.Show("Por favor complete todos los campos");
            }
            else {
                string queryViolento = "EXEC NENE_MALLOC.alta_habitacion "+txtNroHabi.Text+","+txtPisoHotel.Text+","+txtHotel.Text+","+
                    cBTipoHabitacion.SelectedItem.ToString()+",'"+txtConVista.Text+"','"+txtDesc.Text+"'";
                try
                {
                    conexion.executeOnly(queryViolento);
                    MessageBox.Show("Habitacion creada con exito.");
                    this.Close();
                }
                catch (Exception exce){
                    MessageBox.Show(exce.Message);
                }
            }
        }
    }
}
