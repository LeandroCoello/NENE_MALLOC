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
    public partial class GestorPregOResp : Form
    {
        string Fecha = DateTime.Now.ToString("D/M/YYYY");
        string respuesta;
        public GestorPregOResp(string tipoDeFunc)
        {
            InitializeComponent();
            if (tipoDeFunc == "Ver Preguntas")
            {
                /*Mandar consultar al sql pidiendole por todas las preguntas q no ha respondido este usuario
                 para mostrar sobre la data grid view*/
                this.dGVPreguntas.Enabled = true;
            }
            else {
                this.dGVRespuestas.Enabled = true;
                /*Mandar consultar al sql pidiendole por todas las respuesta q le han respondido a este usuario
                 en publicaciones que el halla preguntado algo para mostrar sobre la data grid view*/
            }


        }

        private void dGVPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Gestion_de_Preguntas.Responder levantarRespuesta = new Gestion_de_Preguntas.Responder();
            this.Hide();
        }
        public void ActualizarRespuesta(string unaRespuesta) {
            respuesta = unaRespuesta;
            /*ENVIARLE LA RESPUESTA AL SQL PARA QUE LA AGREGUE*/
        }


    }
}
