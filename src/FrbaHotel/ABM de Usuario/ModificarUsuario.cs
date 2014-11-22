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
    public partial class ModificarUsuario : Form
    {
        Administrador admin;
        SQLConnector conexion;
        string usuarioId;
        string datosPersId;
        public ModificarUsuario(string[] valores,SQLConnector conec)
        {
            InitializeComponent();
            conexion = conec;
            List<string> rolesActuales = admin.rolesSistema();
            BindingSource bs = new BindingSource();
            bs.DataSource = rolesActuales;
            cBRolesAAsignar.DataSource = bs;
            usuarioId = valores[0];
            datosPersId = valores[7];
        }


    }
}
