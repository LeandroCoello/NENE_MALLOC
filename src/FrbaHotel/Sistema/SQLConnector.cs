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


namespace FrbaHotel.Sistema
{
    public class SQLConnector
    {
        private SqlConnection connection;

        public SQLConnector() {
            try
            {
                connection = new SqlConnection("Data Source=localhost/SQLSERVER2008;Initial Catalog=GD1C2014;user=gd;password=gd2014");
                connection.Open();
            }
            catch (Exception) {
                MessageBox.Show("No se pudo conectar");
                
            }
        }


        public int executeIntegerProcedure(string query)
        {
            SqlCommand queryCommand = new SqlCommand(query, connection);
            queryCommand.CommandType = CommandType.StoredProcedure;
            return (int)queryCommand.ExecuteScalar();
        }
        public void executeOnly(string query)
        {   
            SqlCommand queryCommand = new SqlCommand();
            queryCommand.CommandTimeout = 999999999;

            queryCommand.Connection = this.connection;
            queryCommand.CommandText = query;
            queryCommand.ExecuteNonQuery();
            queryCommand.Dispose();
            queryCommand = null;
        }
        public DataTable consulta(string consulta)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandTimeout = 999999999;

            sqlCommand.Connection = this.connection;
            sqlCommand.CommandText = consulta;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(consulta, this.connection);

            DataTable dataTable = new DataTable();
            dataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public UsuarioLogueado registrarse()
        {
            return null;
        }



    }
}
