using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            string queryRegistro = "exec SQL_O.generar_usuario";
            DataTable usuarioNuevo = connection.consulta(queryRegistro);
            string userId = usuarioNuevo.Columns[0].ToString();
            string passSinHash = usuarioNuevo.Columns[1].ToString();
            return new UsuarioLogueado(userId,passSinHash);
        }
        public UsuarioLogueado login(String nombreDeUsuario, String contraseña)
        {

            switch (connection.executeProcedure("exec SQL_O.proc_login User_Id,Userpass FROM SQL_O.Usuario where (User_Id ='" + nombreDeUsuario + "')and (Userpass = '" + this.SHA256Encripta(contraseña) + "')"))
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

        private string SHA256Encripta(string input)
        {
            SHA256Managed provider = new SHA256Managed();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
    }
}
