using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class TieredTaxBracket : ITaxCalculator
    {
        public virtual decimal CalculateTax(decimal amount, decimal deductions)
        {
            var total = 0M;
            var taxableAmount = amount - deductions;

            foreach (var bracket in _taxBrackets.Where(tb => taxableAmount > tb.LowerBound))
            {
                total += bracket.TaxRate * (Math.Min(bracket.UpperBound, taxableAmount) - bracket.LowerBound);
            }

            return total;
        }

        public TieredTaxBracket(ICollection<TaxBracket> taxBrackets)
        {
            _taxBrackets = taxBrackets;
        }

        private ICollection<TaxBracket> _taxBrackets;
    }
}
