using Pretire.Models.Taxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Logic
{
    public class TaxLogic
    {
        public decimal CalculateIncomeTax(decimal income, ICollection<TaxBracket> taxBrackets)
        {
            decimal tax = 0M;
            foreach(var taxBracket in taxBrackets)
            {
                if (income >= taxBracket.LowerBound)
                {
                    tax += taxBracket.TaxRate * (Math.Min(income, taxBracket.UpperBound) - taxBracket.LowerBound);
                }
            }
            return tax;
        }
    }
}
