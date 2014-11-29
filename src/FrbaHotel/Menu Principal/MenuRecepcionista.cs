using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Menu_Principal
{
    public partial class MenuRecepcionista : Form
    {
        UsuarioLogueado userLog;
        public MenuRecepcionista(UsuarioLogueado usuario)
        {
            InitializeComponent();
            userLog = usuario;
        }

        private void btnGENRESER_Click(object sender, EventArgs e)
        {
            Generar_Modificar_Reserva.Generar levantarGenerar = new FrbaHotel.Generar_Modificar_Reserva.Generar(userLog);
            this.Hide();
            levantarGenerar.ShowDialog();
            this.ShowDialog();
        }

        private void btnCancelReser_Click(object sender, EventArgs e)
        {
            Cancelar_Reserva.CancelReser levantarCancel = new FrbaHotel.Cancelar_Reserva.CancelReser(userLog.getConexion(),"recepcionista");
            this.Hide();
            levantarCancel.ShowDialog();
            this.Show();
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.ABMCliente levantarCliente = new FrbaHotel.ABM_de_Cliente.ABMCliente(userLog.getConexion());
            this.Hide();
            levantarCliente.ShowDialog();
            this.Show();
        }

        private void btnRegEst_Click(object sender, EventArgs e)
        {
            Registrar_Estadia.RegEstadia levantarReg = new FrbaHotel.Registrar_Estadia.RegEstadia(userLog.getConexion());
            this.Hide();
            levantarReg.ShowDialog();
            this.Show();
        }

        private void btnRegConsu_Click(object sender, EventArgs e)
        {
            Registrar_Consumible.RegConsumible levantarReg = new FrbaHotel.Registrar_Consumible.RegConsumible(userLog.getConexion());
            this.Hide();
            levantarReg.ShowDialog();
            this.Show();
        }

        private void btnFacPub_Click(object sender, EventArgs e)
        {
            Facturar_Publicaciones.FacturarPublicaciones levantarFac = new FrbaHotel.Facturar_Publicaciones.FacturarPublicaciones(userLog.getConexion());
            this.Hide();
            levantarFac.ShowDialog();
            this.Show();
        }

        private void btnListEsta_Click(object sender, EventArgs e)
        {
            Listado_Estadistico.ListEstadistico levantarListado = new FrbaHotel.Listado_Estadistico.ListEstadistico(userLog);
            this.Hide();
            levantarListado.ShowDialog();
            this.Show();
        }
    }
}
