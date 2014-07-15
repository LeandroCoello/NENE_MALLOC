using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Form1 : Form
    {
        UsuarioLogueado userLog;
        SQLConnector conec;
        string queryCompras;
        string queryOfertas;
        string queryCalif;
        public Form1()
        {
            InitializeComponent();
            /*Realizar consulta al SQL por cada data para ir completando los campos de cada uno*/

            queryCompras = "SELECT * FROM SQL_O.historial_compras('"+ userLog.getNombreUsuario()+"')";
            conec.consulta(queryCompras);
            queryOfertas = "SELECT * FROM SQL_O.historial_ofertas('" + userLog.getNombreUsuario() + "')";
            conec.consulta(queryOfertas);
            queryCalif = "SELECT * FROM SQL_O.historial_calificaciones('" + userLog.getNombreUsuario() + "')";
            conec.consulta(queryCalif);
            this.cargarDatos();
        }
        public void cargarDatos(DataTable compras, DataTable ofertas, DataTable calificaciones)
        { 


        }
    }
}
