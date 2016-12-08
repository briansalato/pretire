using Pretire.Logic.Taxes.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    /// <summary>
    /// FICA Income Tax is based off base salary, not reduced by deductions or contributions
    /// </summary>
    public abstract class FICAIncomeTaxCalculator : TieredIncomeTaxCalculator
    {
        protected override decimal CalculateTaxableSalary(decimal salary, decimal contributionTo401k, decimal deductionAmount)
        {
            return salary;
        }

        public FICAIncomeTaxCalculator(ICollection<TaxBracket> taxBrackets)
            : base(taxBrackets) { }
    }
}
