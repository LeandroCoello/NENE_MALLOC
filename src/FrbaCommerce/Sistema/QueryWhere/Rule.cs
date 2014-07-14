using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Sistema.QueryWhere
{
    class Rule : Condition
    {
        String exp;

        String toString()
        {
            return exp; 
        }
        
    }
}
