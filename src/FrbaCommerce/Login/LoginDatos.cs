using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Login
{
    class LoginDatos
    {
        public static int logeoSql(string nombreUsuario, string passHaseada) {
            int query = int.Parse("ACA VA EL SELECT");
            return query;
        }
        public static List<string> cantidadDeRoles(string nombreUsuario) {
        List<string> rolesUsuario = new List<string>();
            //ACA HAY QUE HACER EL SELECT PARA PEDIR TODOS LOS ROLES QUE TIENE
        return rolesUsuario;
        }
    }
}
