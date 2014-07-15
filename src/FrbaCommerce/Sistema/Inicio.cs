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
        public UsuarioLogueado registrarse(String nombreDeUruario)
        {
            
            return null;
        }
        public UsuarioLogueado login(String nombreDeUsuario, String contraseña)
        {

            switch (connection.logearse("exec SQL_O.proc_login User_Id,Userpass FROM SQL_O.Usuario where (User_Id ='" + nombreDeUsuario + "')and (Userpass = '" + contraseña + "')"))
            {
                case 0:
                return new UsuarioLogueado(nombreDeUsuario, contraseña, connection);
                case 1:
                case 2:
                case 3:
                    
            }
            return null;
        }
    }
}
