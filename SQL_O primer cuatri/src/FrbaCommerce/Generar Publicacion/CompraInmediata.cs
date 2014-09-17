using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class CompraInmediata : Form
    {
        string FechaInicio = DateTime.Now.ToString("D/M/yyyy");
        List<String> campos = new List<string>();
        public CompraInmediata(string tipoElegido)
        {
            InitializeComponent();
            lBEstados.Items.Add("Borrador");
            lBEstados.Items.Add("Activa");
            lBEstados.Items.Add("Pausada");
            lBEstados.Items.Add("Finalizada");
        }

        private bool validarCampos() {
            campos.Add(lBVisibilidades.SelectedItem.ToString());
            campos.Add(lBRubros.SelectedItem.ToString());
            campos.Add(lBEstados.SelectedItem.ToString());
            campos.Add(txtStock.Text);
            campos.Add(txtPrecio.Text);
            campos.Add(txtDesc.Text);
            return !campos.Any(unCampo => string.IsNullOrEmpty(unCampo));
        }
        private bool TildoPregunta() {
            return cBNo.Checked || cBSi.Checked;
        }

        private void btnConfirmacion_Click(object sender, EventArgs e)
        {
            if (this.validarCampos() && this.TildoPregunta())
            {
                /*ENVIAR DATOS AL SQL PARA CREAR LA NUEVA PUBLICACION 
                 EL MISMO SE ENCARGA DE GENERAR EL NUEVO CODIGO DE LA PUBLICACION*/
                MessageBox.Show("Publicacion Creada con exito");
                this.Close(); 
            }
            else
                MessageBox.Show("Por favor complete todos los campos");
                
                
        }
    }
}
