using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryConditions
{
    class Rule : Condition
    {
        String exp;

        public Rule(String expression)
        {
            exp = expression;
        }

        String toString()
        {
            return exp; 
        }
        
    }
}
