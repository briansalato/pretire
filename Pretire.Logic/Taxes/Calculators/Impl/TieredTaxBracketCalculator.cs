using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class TieredTaxBracketCalculator : ITaxCalculator
    {
        public virtual decimal CalculateTax(decimal amount, decimal deductions)
        {
            var total = 0M;
            var taxableAmount = amount;
            if (_useDeductions)
            {
                taxableAmount -= deductions;
            }

            foreach (var bracket in _taxBrackets.Where(tb => taxableAmount > tb.LowerBound))
            {
                total += bracket.TaxRate * (Math.Min(bracket.UpperBound, taxableAmount) - bracket.LowerBound);
            }

            return total;
        }

        public TieredTaxBracketCalculator(ICollection<TaxBracket> taxBrackets, bool useDeductions)
        {
            _taxBrackets = taxBrackets;
            _useDeductions = useDeductions;
        }

        private ICollection<TaxBracket> _taxBrackets;
        private bool _useDeductions;
    }
}
