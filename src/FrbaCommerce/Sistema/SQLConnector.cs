using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;


namespace FrbaCommerce.Sistema
{
    class SQLConnector
    {
        private SqlConnection connection;

        private SQLConnector() {
            try
            {
                connection = new SqlConnection("Data Source=localhost/SQLSERVER2008;Initial Catalog=GD1C2014;user=gd;password=gd2014");
                connection.Open();
            }
            catch (Exception) {
                MessageBox.Show("No se pudo conectar");
                
            }
        }

        public List<string> ObtenerRoles(string queri) {
            return null;
        }


        public object logearse(string query)
        {
            SqlCommand queryCommand = new SqlCommand(query, connection);
            queryCommand.CommandType = CommandType.StoredProcedure;
            return queryCommand.ExecuteScalar();
       
        }        
        public void consulta(string consulta)
        {
          
        }
        public UsuarioLogueado registrarse()
        {
            return null;
        }

    }
}
