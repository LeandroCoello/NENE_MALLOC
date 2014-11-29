using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Generar_Modificar_Reserva
{
    public partial class BuscarCliente : Form
    {
        UsuarioLogueado usuario;
        public BuscarCliente(UsuarioLogueado userLog)
        {
            InitializeComponent();
            usuario = userLog;
        }
    }
}
