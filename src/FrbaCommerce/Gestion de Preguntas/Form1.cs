using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lBpreguntas.Items.Add("Ver Preguntas");
            lBpreguntas.Items.Add("Ver Respuestas");
        }

        private void btnAcep_Click(object sender, EventArgs e)
        {
            string tipoDeFuncionalidad = lBpreguntas.SelectedItem.ToString();
            if (string.IsNullOrEmpty(tipoDeFuncionalidad))
            {
                Gestion_de_Preguntas.GestorPregOResp levantarGestor = new GestorPregOResp(tipoDeFuncionalidad);
                levantarGestor.ShowDialog();
                this.Hide();
            }
            else
                MessageBox.Show("Por favor seleccione un campo");
        }
    }
}
