using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;
using FrbaCommerce.Sistema.QueryConditions;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class Filtrar : Form
    {
        SQLConnector conec = new SQLConnector();
        Condition condicion;
        
        public Filtrar()
        {
            InitializeComponent();
            
 
        }

        private void Filtrar_Load(object sender, EventArgs e)
        {

        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            List<string> valores = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                valores.Add(row.ToString());
            }
            Modificar levantarModif = new Modificar(valores);
            levantarModif.ShowDialog();
            this.Hide();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            List<string> valores = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                valores.Add(row.ToString());
            }
            Baja levantarBaja = new Baja(valores);
            levantarBaja.ShowDialog();
            this.Hide();

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) && string.IsNullOrEmpty(txtDuracion.Text))
            {
               string queryTabla = "SELECT V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje FROM SQL_O.Visibilidad"
               + "GROUP BY V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje";
               dataGridView1.DataSource = conec.consulta(queryTabla);
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text)) {
                string queryTabla = "SELECT V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje FROM SQL_O.Visibilidad"
                                    + "WHERE (V.Vis_Duracion = LIKE%'" + txtDuracion + "'%)"
                                    + "GROUP BY V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje";
                dataGridView1.DataSource = conec.consulta(queryTabla);
           }
            else if (string.IsNullOrEmpty(txtDuracion.Text))
            {
                string queryTabla = "SELECT V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje FROM SQL_O.Visibilidad"
                    + "WHERE(V.Vis_Descripcion = '" + txtDescripcion + "')"
                    + "GROUP BY V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje";
                dataGridView1.DataSource = conec.consulta(queryTabla);
            }
            else
            {
                string queryTabla = "SELECT V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje FROM SQL_O.Visibilidad"
                    + "WHERE (V.Vis_Duracion = LIKE%'" + txtDuracion + "'%)"
                    + "and (V.Vis_Descripcion = '" + txtDescripcion + "')"
                    + "GROUP BY V.Vis_Cod,V.Vis_Desc,V.Vis_Duracion,V.Vis_Precio,V.Vis_Porcentaje";
                    dataGridView1.DataSource = conec.consulta(queryTabla);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDuracion.Clear();
            txtDescripcion.Clear();

        }
    }
}
