using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


 
namespace FrbaCommerce.Sistema
{
    public class Publicacion
    {
        private int cod;
        private Double precio;
        private DateTime pub_ini_time;
        private DateTime pub_fecha_vto;
        private char estado;
        private String tipo;
        private SQLConnector con; 

        public Publicacion(int c, Double d, String t, char e, SQLConnector con)
        { 

        }
         
        public void conseguirPreguntas()
        {
            String query = "SELECT pre.Pre_Id, pre.Pre_Texto FROM SQL_O.Pregunta pre, SQL_O.Publcacion pub"
                                    +"WHERE pre.Pre_Pub =" + this.cod.ToString();
            DataTable preguntasSinResponder = con.consulta(query);

        }
    }
   

}

