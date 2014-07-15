using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Sistema;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class Form1 : Form
    {
        UsuarioLogueado userLog;
        SQLConnector conec;
        string queryCompras;
        string queryOfertas;
        string queryCalifOtor;
        string queryCalifRecib;
        public Form1()
        {
            InitializeComponent();
            /*Realizar consulta al SQL por cada data para ir completando los campos de cada uno*/

            queryCompras = "SELECT P.Pub_Cod,P.Pub_Desc,P.Pub_Dueño,P.Pub_Precio,C.Compra_Fecha FROM SQL_O.Publicacion P, SQL_O.Compra C "
                            + "WHERE (C.Compra_comprador ='" + userLog.getNombreUsuario() + "') and"
                            + "P.Pub_dueño <> C.Compra_comprador and P.Pub_Cod = C.Compra_Pub and "
                            + "GROUP BY P.Pub_Cod,P.Pub_Desc,P.Pub_Dueño,P.Pub_Precio,C.Compra_Fecha";
            conec.consulta(queryCompras);
            queryOfertas = "SELECT O.Oferta_Pub,P.Pub_Desc,O.Oferta_Monto,O.Oferta_Fecha FROM SQL_O.Oferta O, SQL_O.Publicacion P"
                            + "WHERE (O.Oferta_Cliente ='" + userLog.getNombreUsuario() + "') and"
                            + "O.Oferta_Pub = P.Pub_Cod and"
                            + "P.Pub_dueño <> O.Oferta_Cliente"
                            + "GROUP BY O.Oferta_Pub,P.Pub_Desc,O.Oferta_Monto,O.Oferta_Fecha";
            conec.consulta(queryOfertas);
            queryCalifOtor = "SELECT C.Cal_Pub,P.Pub_dueño,C.Cal_Desc,C.Cal_Cant_Est FROM SQL_O.Calificacion C, SQL_O.Publicacion"
                             + "WHERE (C.Cal_user ='" + userLog.getNombreUsuario() + "') and"
                             + "P.Pub_dueño <> C.Cal_user and"
                             + "P.Pub_Cod = C.Cal_Pub"
                             + "GROUP BY C.Cal_Pub,P.Pub_dueño,C.Cal_Desc,C.Cal_Cant_Est";
            conec.consulta(queryCalifOtor);
            queryCalifRecib = "SELECT C.Cal_Pub,C.Cal_user,C.Cal_Desc,C.Cal_Cant_Est FROM SQL_O.Calificacion C, SQL_O.Publicacion"
                             + "WHERE (P.Pub_dueño ='" + userLog.getNombreUsuario() + "') and"
                             + "P.Pub_dueño <> C.Cal_user and"
                             + "P.Pub_Cod = C.Cal_Pub"
                             + "GROUP BY C.Cal_Pub,P.Pub_dueño,C.Cal_Desc,C.Cal_Cant_Est";
            conec.consulta(queryCalifRecib);
        }
    }
}
