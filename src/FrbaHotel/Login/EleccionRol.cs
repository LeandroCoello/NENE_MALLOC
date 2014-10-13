using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class EleccionRol : Form
    {
        public EleccionRol(List<string> rolesACargar)
        {
            InitializeComponent();
            foreach (var rol in rolesACargar) {
                lBEleccionRoles.Items.Add(rol);
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lBEleccionRoles.SelectedItem.ToString())) {
                MessageBox.Show("Por favor elija un rol");
            }
            string selected = lBEleccionRoles.SelectedValue.ToString();
            FrbaHotel.Menu_Principal.MenuPrincipal levantarMenu = new FrbaHotel.Menu_Principal.MenuPrincipal(selected);
            this.Hide();
            levantarMenu.ShowDialog();
        }

    }
}
