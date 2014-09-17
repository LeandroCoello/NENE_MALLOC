using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryConditions
{
   public class And : FrbaCommerce.Sistema.QueryConditions.Condition
    {
        private Condition exp1;
        private Condition exp2;

      public And(Condition e1, Condition e2)
        {
            this.exp1 = e1;
            this.exp2 = e2;
        }

      string Condition.toString()
        {
            if (exp1.toString() == null || exp2.toString() == null)
            {
                return exp1.toString() + exp2.toString();
            }
            return exp1.toString() + " AND " + exp2.toString();
        }
    }
}
