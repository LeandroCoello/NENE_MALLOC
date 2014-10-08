using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace FrbaHotel.Sistema
{
    public class UsuarioLogueado
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
        public String getNombreUsuario()
        {
            return nombreUsuario;
        }
        public String getContraseña() {
            return contraseñaHash;
        }

        public List<String> conseguirRoles()
        {
            string queryRoles = "SELECT R.Rol_Desc FROM SQL_O.Rol R,SQL_O.Usuarios_Por_Rol UR,SQL_O.Usuario U"
                                + "WHERE U.Username ='" + nombreUsuario + "'"
                                + "and UR.UserId = U.User_Id"
                                + "and UR.Rol_Cod = R.Rol_Cod"
                                + "and R.Rol_baja = 0"
                                + "GROUP BY Rol_Cod";
            DataTable roles = conexion.consulta(queryRoles);
            List<string> rolesAsignados = new List<string>();
            foreach (DataRow row in roles.Rows) {
                rolesAsignados.Add((string)row[0]);
            }
            return rolesAsignados;
        }
    }
}
