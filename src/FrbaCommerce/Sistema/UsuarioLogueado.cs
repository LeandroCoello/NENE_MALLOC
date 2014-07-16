using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace FrbaCommerce.Sistema
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
        public UsuarioLogueado(String nom, String passSinHash) {
            this.contraseñaHash = passSinHash;
            this.nombreUsuario = nom;
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
            string queryRoles = "SELECT R.Rol_Desc FROM SQL_O.Rol R,SQL_O.Tipo T,SQL_O.Usuario U"
                                +"WHERE R.Rol_Cod=T.Tipo_Rol"
                                + "and (U.User_Id ='" + nombreUsuario + "')"
                                +"and U.User_Tipo = T.Tipo_Cod"
                                +"GROUP BY R.Rol_Desc";
            DataTable roles = conexion.consulta(queryRoles);
            List<string> rolesAsignados = new List<string>();
            foreach (DataRow row in roles.Rows) {
                rolesAsignados.Add((string)row[0]);
            }
            return rolesAsignados;
        }
        public List<Publicacion> conseguirPublicaciones()
        {
            //aca va la logica del query de publicaciones
            return null;
        }

    }
}
