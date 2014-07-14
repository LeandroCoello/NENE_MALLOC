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
    public partial class Responder : Form 
    {
        string respuesta;
        GestorPregOResp FormPadre;
        public Responder()
        {
            InitializeComponent();
        }

        private void btnEnvioRespuesta_Click(object sender, EventArgs e)
        {
            respuesta = textBox1.Text;
            if (string.IsNullOrEmpty(respuesta))
            {
                MessageBox.Show("Por favor complete la respuesta");
            }
            else 
            {
                FormPadre.ActualizarRespuesta(respuesta);
                MessageBox.Show("Respuesta enviada satisfactoriamente");
                this.Close();
            }

        }
    }
}
