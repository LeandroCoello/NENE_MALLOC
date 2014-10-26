using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Rol
{
    public partial class ListadoRol : Form
    {
        string criterio;
        public ListadoRol(string condicion)
        {
            InitializeComponent();
            criterio = condicion;
            cBEstadoRol.Items.Add("Habilitado");
            cBEstadoRol.Items.Add("Deshabilitado");
            //BUSCAR DE UN DATA TABLE ROBARLE LOS CAMPOS PARA METERLOS EN UN COMBO BOX PARA LAS FUNCIONALIDADES
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtNomRol.Text = "";
            cBEstadoRol.SelectedIndex = -1;
            cBFuncionalidades.SelectedIndex = -1;
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string queryFinal = "SELECT * FROM NENE_MALLOC.Rol";
            if (!string.IsNullOrEmpty(txtNomRol.Text)) 
            {
                queryFinal += "and NENE_MALLOC.Rol.Rol_Desc LIKE %"+txtNomRol.Text+"%";
            }

        }
    }
}
