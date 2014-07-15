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
        string queryCompras;
        string queryOfertas;
        string queryCalif;
        public Form1()
        {
            InitializeComponent();
            this.cargarDatos();
        }
        public void cargarDatos()
        {
            SQLConnector conec = new SQLConnector();
            queryCompras = "SELECT * FROM SQL_O.historial_compras('" + userLog.getNombreUsuario() + "')";
            queryOfertas = "SELECT * FROM SQL_O.historial_ofertas('" + userLog.getNombreUsuario() + "')";
            queryCalif = "SELECT * FROM SQL_O.historial_calificaciones('" + userLog.getNombreUsuario() + "')";

            dGVCompras.DataSource = conec.consulta(queryCompras);
            dGVOfertas.DataSource = conec.consulta(queryOfertas);
            dGVCalifOtor.DataSource = conec.consulta(queryCalif);

        }
    }
}
