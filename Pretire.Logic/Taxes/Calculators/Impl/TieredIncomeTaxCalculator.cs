using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class TieredIncomeTaxCalculator : IIncomeTaxCalculator
    {
        public virtual decimal CalculateTax(decimal salary, decimal contributionTo401k, decimal deductionAmount)
        {
            var total = 0M;
            var taxableAmount = CalculateTaxableSalary(salary, contributionTo401k, deductionAmount);

            foreach (var bracket in _taxBrackets.Where(tb => taxableAmount > tb.LowerBound))
            {
                total += bracket.TaxRate * (Math.Min(bracket.UpperBound, taxableAmount) - bracket.LowerBound);
            }

            return total;
        }

        protected virtual decimal CalculateTaxableSalary(decimal salary, decimal contributionTo401k, decimal deductionAmount)
        {
            return salary - contributionTo401k - deductionAmount;
        }

        #region Constructors
        public TieredIncomeTaxCalculator(ICollection<TaxBracket> taxBrackets)
        {
            _taxBrackets = taxBrackets;
        }
        #endregion

        #region Instance Variables
        private ICollection<TaxBracket> _taxBrackets;
        #endregion
    }
}
