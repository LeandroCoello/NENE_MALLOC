using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.Sistema
{
    class Inicio
    {
        SQLConnector connection;
        public Inicio(SQLConnector connectionInstance)
        {
            this.connection = connectionInstance;
        }
        public UsuarioLogueado registrarse()
        {
            return null;
        }
        public UsuarioLogueado login()
        {
            return null;
        }
    }
}
