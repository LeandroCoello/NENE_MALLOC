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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lBTiposDePub.Items.Add("Compra Inmediata");
            lBTiposDePub.Items.Add("Subasta");
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            string tipoElegido = lBTiposDePub.SelectedItem.ToString();

            switch (tipoElegido){
                case "Compra Inmediata":
                    Generar_Publicacion.CompraInmediata levantarCompra = new Generar_Publicacion.CompraInmediata(tipoElegido);
                    levantarCompra.ShowDialog();
                    this.Hide();
                    break;
                case "Subasta":
                    Generar_Publicacion.Subasta levantarSubasta = new Generar_Publicacion.Subasta(tipoElegido);
                    levantarSubasta.ShowDialog();
                    this.Hide();
                    break;
                default:
                    MessageBox.Show("Eliga un tipo");
                    break;
            }
        }
    }
}
