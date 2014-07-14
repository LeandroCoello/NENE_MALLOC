using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryConditions
{
    class Or : Condition
    {
        private Condition exp1;
        private Condition exp2;

        public Or(Condition e1, Condition e2)
        {
            this.exp1 = e1;
            this.exp2 = e2;
        }
        String toString()
        {
            return exp1.toString() + " OR " + exp2.toString();
        }
    }
}
