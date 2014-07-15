using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema
{
    class UsuarioLogueado
    {
        private SQLConnector conexion;
        private String nombreUsuario;
        private String contraseñaHash;
        public UsuarioLogueado(String n,String c, SQLConnector con)
        {
            this.nombreUsuario = n;
            this.contraseñaHash = c;
            this.conexion = con;
        }
    }
}
