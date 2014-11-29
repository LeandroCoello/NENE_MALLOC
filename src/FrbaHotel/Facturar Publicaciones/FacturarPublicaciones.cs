using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Facturar_Publicaciones
{
    public partial class FacturarPublicaciones : Form
    {
        UsuarioLogueado usuario;
        String fechaSistema = Convert.ToDateTime(ConfigurationSettings.AppSettings["fecha"]).ToString("yyyyMMdd"); 
        public FacturarPublicaciones(UsuarioLogueado userLog)
        {
            InitializeComponent();
            usuario = userLog;
            cBFormaPago.Items.Add("Efectivo");
            cBFormaPago.Items.Add("Tarjeta credito");
        }
    }
}
