using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema
{
    class SistemaPrincipal
    {
        public SQLConnector connectionSQL;
        public SistemaPrincipal(string stringDeConexion)
        {
           this.conectar(stringDeConexion);
        }
        public Login login()
        {
            return new Login(this);
        }
        public Registro registrarse()
        {
            return new Registro(this);
        }

        private void conectar(String stringDeConexion)
        {
             this.connectionSQL = null;
        }
       
    }
}
