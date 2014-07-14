using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryWhere
{
    class Or : Condition
    {
        private Condition exp1;
        private Condition exp2;

        String toString()
        {
            return exp1.toString() + " OR " + exp2.toString();
        }
    }
}
