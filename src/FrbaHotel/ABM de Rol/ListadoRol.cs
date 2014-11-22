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
    public partial class ListadoRol : Form
    {
        SQLConnector conexion;
        string criterioABM;
        public ListadoRol(string condicion, SQLConnector conec)
        {
            InitializeComponent();
            criterioABM = condicion;
            conexion = conec;
            cBEstadoRol.Items.Add("1");
            cBEstadoRol.Items.Add("0");
            DataTable funcionalidades = conexion.consulta("SELECT Func_Desc FROM NENE_MALLOC.Funcionalidad");
            foreach (DataRow row in funcionalidades.Rows) 
            {
                cBFuncionalidades.Items.Add(row["Func_Desc"]);
            }
        }

        private void btnLimpieza_Click(object sender, EventArgs e)
        {
            txtNomRol.Text = "";
            cBEstadoRol.SelectedIndex = -1;
            cBFuncionalidades.SelectedIndex = -1;
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            string queryFinal = "SELECT R.Rol_Id,R.Rol_Desc,R.Rol_estado FROM NENE_MALLOC.Rol R, NENE_MALLOC.Func_Por_Rol FR, NENE_MALLOC.Funcionalidad F "+
                "WHERE R.Rol_Id = FR.Rol_Id AND FR.Func_Id = F.Func_Id";
            string ultimaClausula =  "GROUP BY R.Rol_Id,R.Rol_Desc,R.Rol_estado";
            if (!string.IsNullOrEmpty(txtNomRol.Text)) 
            {
                queryFinal += "and R.Rol_Desc LIKE '%"+txtNomRol.Text+"%'";
            }
            if (!string.IsNullOrEmpty(cBFuncionalidades.SelectedItem.ToString())) 
            {
                queryFinal += "and F.Func_Desc LIKE '%"+cBFuncionalidades.SelectedItem.ToString()+"'%";
            }
            if (!string.IsNullOrEmpty(cBEstadoRol.SelectedItem.ToString())) 
            {
                queryFinal +=  "and R.Rol_Estado LIKE '%"+cBEstadoRol.SelectedItem.ToString()+"'%";  
            }
            queryFinal += ultimaClausula;
              dataGridView1.DataSource =  conexion.consulta(queryFinal);
              DataGridViewButtonColumn col = new DataGridViewButtonColumn();
              col.UseColumnTextForButtonValue = true;
              col.Text = "Seleccionar";
              col.Name = "Seleccionar";
              dataGridView1.Columns.Add(col);
        }
    }
}
