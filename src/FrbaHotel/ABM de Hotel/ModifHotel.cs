using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaHotel.Sistema;

namespace FrbaHotel.ABM_de_Hotel
{
    public partial class ModifHotel : Form
    {
        SQLConnector conexion;
        string hotelId;
        List<TextBox> boxes = new List<TextBox>();
        public ModifHotel(string[] valores, SQLConnector conec )
        {
            InitializeComponent();
            conexion = conec;
            hotelId = valores[0];
            this.generarBoxes();
            this.cargarBoxes(valores);
            DataTable regiActuales = conec.consulta("SELECT R.Regimen_Desc FROM NENE_MALLOC.Hotel H,NENE_MALLOC.Regimen_Por_Hotel RH,NENE_MALLOC.Regimen R WHERE H.Hotel_Id = RH.Hotel_Id AND R.Regimen_Id = RH.Regimen_Id AND H.Hotel_Id = "+hotelId);
            foreach (DataRow row in regiActuales.Rows) {
                lBRegim.Items.Add(row["Regimen_Desc"].ToString());
            }
            DataTable regiAgregar = conec.consulta("SELECT R.Regimen_Desc FROM NENE_MALLOC.Regimen R ");
            foreach (DataRow row in regiAgregar.Rows)
            {
                if (!lBRegim.Items.Contains(row["Regimen_Desc"].ToString()))
                {
                    lBRegimAgregar.Items.Add(row["Regimen_Desc"].ToString());
                }
            }
        }
        private void generarBoxes()
        {
            boxes.Add(txtNom);
            boxes.Add(txtMail);
            boxes.Add(txtTelefono);
            boxes.Add(txtDom);
            boxes.Add(txtNroCalle);
            boxes.Add(txtCiudad);
            boxes.Add(txtPais);
            boxes.Add(txtEstrellas);
        }
        private void cargarBoxes(string[] unaLista)
        {
            int i = 1;
            foreach (var txtB in boxes)
            {
                txtB.Text = unaLista[i];
                i++;
                if (i >= unaLista.Length)
                {
                    break;
                }
            }
        }

        private void btnModifr_Click(object sender, EventArgs e)
        {
            string queryFinal = "EXEC NENE_MALLOC.modificacion_hotel '"+txtNom.Text+"','"+txtMail.Text+"',"+txtTelefono.Text+",'"+txtDom.Text+"',"+txtNroCalle.Text+",'"+txtCiudad.Text+"','"+txtPais.Text+"',"+txtEstrellas.Text+",10,"+hotelId;
            try
            {
                conexion.executeOnly(queryFinal);
                if (lBRegim.SelectedIndex != -1) {
                    foreach (var item in lBRegim.SelectedItems) {
                        DataTable iDR = conexion.consulta("SELECT Regimen_Id FROM NENE_MALLOC.Regimen WHERE Regimen_Desc = '" + item.ToString() + "'");
                        string idRegimen = iDR.Rows[0].ItemArray[0].ToString();
                        conexion.executeOnly("DELETE NENE_MALLOC.Regimen_Por_Hotel WHERE Hotel_Id ="+hotelId+" AND Regimen_Id = "+idRegimen);
                      }
                }
                if (lBRegimAgregar.SelectedIndex != -1) {
                    foreach (var item in lBRegimAgregar.SelectedItems)
                    {
                        DataTable iDR = conexion.consulta("SELECT Regimen_Id FROM NENE_MALLOC.Regimen WHERE Regimen_Desc = '" + item.ToString() + "'");
                        string idRegimen = iDR.Rows[0].ItemArray[0].ToString();
                        conexion.executeOnly("INSERT INTO NENE_MALLOC.Regimen_Por_Hotel(Hotel_Id,Regimen_Id) values (" + hotelId + "," + idRegimen+")");
                    }
                }
                MessageBox.Show("Hotel modificado con exito");
                this.Close();
            }
            catch (Exception exe) {
                MessageBox.Show(exe.Message);
            }
        }

    }
}
