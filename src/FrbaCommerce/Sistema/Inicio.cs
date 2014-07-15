using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            switch (connection.executeProcedure("exec SQL_O.proc_login User_Id,Userpass FROM SQL_O.Usuario where (User_Id ='" + nombreDeUsuario + "')and (Userpass = '" + contraseña + "')"))
            {
                case 0:
                return new UsuarioLogueado(nombreDeUsuario, contraseña, connection);
                case 1:
                throw new Exception("usuario inhabilitado");
                case 2:
                throw new Exception("usuario dado de baja");
                case 3:
                throw new Exception("contraseña incorrecta");
                case 4:
                throw new Exception("El usuario no existe");
                    
            }
            return null;
        }
    }
}
