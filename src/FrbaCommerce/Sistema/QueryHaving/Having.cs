using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrbaCommerce.Sistema.QueryConditions;

namespace FrbaCommerce.Sistema.QueryHaving
{
    class Having
    {
        private Condition exp;
        public String toString()
        {
            return "HAVING" + exp.ToString();
        }
        public Having(Condition expression)
        {
            this.exp = expression;
        }
        public void andExp(Condition expression2)
        {
            this.exp = new And(this.exp, expression2);
        }
        public void orExp(Condition expression2)
        {
            this.exp = new Or(this.exp, expression2);
        }
    }
}
