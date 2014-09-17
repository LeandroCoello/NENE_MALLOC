using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema
{
    public class Item_Factura
    {
        private int id;
        private Double monto;
        public Item_Factura(int i, Double m)
        {
            id = i;
            m = monto;
        }
        public void facturar(SQLConnector con, int fact_id)
        {
            String query = "UPDATE Item_Factura SET Item_Factura =" + fact_id.ToString()+
                            "WHERE Item_Id =" + id.ToString();
            con.executeOnly(query);
        }
    }
}
