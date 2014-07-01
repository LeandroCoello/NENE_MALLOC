using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
            cbTipoDoc.Items.Add("DNI");
            cbTipoDoc.Items.Add("CI");
        }
            //El teléfono es un
            //dato único, por ende no pueden existir 2 clientes con el mismo teléfono.
            //Cuando hacemos boton dar de alta le damos los datos al sql y crea un user con pass para todos estos datos 
            //podriamos mostrar una ventana nueva en la q se muestre el user y pass con los q se dio de alta este usuario
            //validar que todos los datos estan bien BLA BLA BLA 

    }
}
