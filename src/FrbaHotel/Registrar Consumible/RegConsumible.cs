﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.Registrar_Consumible
{
    public partial class RegConsumible : Form
    {
        SQLConnector conexion;
        string descrip;
        public RegConsumible(SQLConnector conecc)
        {
            InitializeComponent();
            conexion = conecc;
        }
        public string getDesc() { return descrip; }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            AgregarConsu levantar = new AgregarConsu(this,conexion);
            this.Hide();
            levantar.ShowDialog();
            this.Show();
        }
        public void agregarAlGrid(string descripcion, string cantidad) 
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = descripcion;
            row.Cells[1].Value = cantidad;
            dataGridView1.Rows.Add(row);
        }
        public void modificarGrid(string desc, string cantidad) 
        {
            int rowIndex = -1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(desc))
                {
                    rowIndex = row.Index;
                    break;
                }
            }
            dataGridView1.Rows[rowIndex].Cells[1].Value = cantidad;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[2].Index )
            {
                descrip = dataGridView1[0, e.RowIndex].Value.ToString();
                ModifConsu levantarModif = new ModifConsu(this);
                this.Hide();
                levantarModif.ShowDialog();
                this.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns[3].Index ) 
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                dataGridView1.Refresh();
            }
            this.Show();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (txtNroHab.Text == "" || txtNroReserva.Text == "") { MessageBox.Show("Complete todos los campos"); }
            else
            {
                string rphId;
                string cant;
                DataTable phid = conexion.consulta("SELECT RPH_Id FROM NENE_MALLOC.Reserva_Por_Habitacion WHERE Reserva_Id = " + txtNroReserva.Text + " AND Habitacion_Id = " + txtNroHab.Text);
                rphId = phid.Rows[0].ItemArray[0].ToString();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cant = row.Cells[1].Value.ToString();
                    DataTable consuId = conexion.consulta("SELECT Consumible_Id FROM NENE_MALLOC.Consumible WHERE Consumible_Desc LIKE '%"+row.Cells[0].Value.ToString()+"%'");
                    string query = "EXEC NENE_MALLOC.alta_consumible_habitacion " + rphId + "," + consuId.Rows[0].ItemArray[0].ToString() + "," + cant;
                    conexion.executeOnly(query);
                }
                MessageBox.Show("Registracion exitosa");
                this.Close();
            }

        }

    }
}
