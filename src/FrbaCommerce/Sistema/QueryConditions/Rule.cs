using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryConditions
{
    class Regla : Condition
    {
        String exp;

        public Regla(String expression)
        {
            exp = expression;
        }

        String toString()
        {
            return exp; 
        }
        
    }
}
