using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryConditions
{
    public class Regla : Condition
    {
        String exp;

        public Regla(String expression)
        {
            exp = expression;
        }

       string Condition.toString()
        {
            return exp; 
        }
        
    }
}
