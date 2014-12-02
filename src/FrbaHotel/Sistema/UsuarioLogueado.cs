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
        private Double hotelAsignado;
       
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
        public SQLConnector getConexion() {
            return conexion;
        }
        public void setHotelAsignado(Double hotelId) {
            hotelAsignado = hotelId;
        }
        public Double getHotelAsignado() {
            return hotelAsignado;
        }

        public List<String> conseguirRolesUsuario()
        {
            string queryRoles = "SELECT R.Rol_Desc FROM NENE_MALLOC.Rol R,NENE_MALLOC.Usuario_Por_Rol_Por_Hotel UR,NENE_MALLOC.Usuario U WHERE U.Usuario_name ='"+nombreUsuario+"' and UR.Usuario_Id = U.Usuario_Id and UR.Rol_Id = R.Rol_Id and R.Rol_estado = 0";
            DataTable roles = conexion.consulta(queryRoles);
            List<string> rolesAsignados = new List<string>();
            foreach (DataRow row in roles.Rows) {
                rolesAsignados.Add(row[0].ToString());
            }
            return rolesAsignados;
        }
        public List<Double> conseguirHotelesId() 
        {
            string queryHotele = "SELECT H.Hotel_Id FROM NENE_MALLOC.Usuario_Por_Rol_Por_Hotel H,NENE_MALLOC.Usuario U WHERE U.usuario_name = '"+nombreUsuario+"' AND U.Usuario_Id = H.Usuario_Id";
            DataTable hoteles = conexion.consulta(queryHotele);
            List<Double> hotelesId = new List<double>();
            foreach (DataRow row in hoteles.Rows) 
            {
                hotelesId.Add(Convert.ToDouble(row[0]));
            }
            return hotelesId;
        }
        public string conseguirIdUser() {
            string ID = null;
            string queryId = "SELECT U.Usuario_Id FROM NENE_MALLOC.Usuario U Where U.Usuario_name =" + nombreUsuario;
            DataTable id = conexion.consulta(queryId);
            foreach(DataRow row in id.Rows){
                ID = row[0].ToString();
            }
            return ID;
        }
    }
}
