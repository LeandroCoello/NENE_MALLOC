using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema
{
    interface Administrador
    {
        public List<String> vendedoresConMayorFacturacion()
        {
            return null;
        }
        public List<String> vendedoresConMayoresCalificaciones()
        {
            return null;
        }
        public List<String> clientesConMayorCantidadDePublicacionesSinCalificar()
        {
            return null;
        }
    }
}
