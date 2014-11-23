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
    public partial class ModificarRol : Form
    {
        SQLConnector conexion;
        string rolId;
        public ModificarRol(string[] listaValores ,SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            rolId = listaValores[0];
            DataTable funcActuales = conec.consulta("SELECT F.Func_Desc FROM NENE_MALLOC.Rol R, NENE_MALLOC.Func_Por_Rol FR, NENE_MALLOC.Funcionalidad F WHERE R.Rol_Id = FR.Rol_Id AND FR.Func_Id = F.Func_Id AND R.Rol_Id ="+rolId);
            foreach(DataRow row in funcActuales.Rows){
                cBFuncActuales.Items.Add(row["Func_Desc"].ToString());
            }
            DataTable funcSistema = conec.consulta("SELECT Func_Desc FROM NENE_MALLOC.Funcionalidad");
            foreach (DataRow row in funcActuales.Rows)
            {
                cBFuncAAgregar.Items.Add(row["Func_Desc"].ToString());
            }
            txtEstado.Text = listaValores[2];
            txtNomRol.Text = listaValores[1];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string query = "EXEC NENE_MALLOC";
            conexion.executeOnly(query);
        }
    }
}
