using Pretire.Logic.Taxes.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class SingleFilingIncomeTaxCalculator : TieredIncomeTaxCalculator
    {
        protected override decimal CalculateTaxableSalary(decimal salary, decimal contributionTo401k, decimal deductionAmount)
        {
            return salary - contributionTo401k - deductionAmount;
        }


        #region Constructors
        public SingleFilingIncomeTaxCalculator()
            :base(USA_SINGLE_TAX_BRACKETS) { }

        public SingleFilingIncomeTaxCalculator(ICollection<TaxBracket> taxBrackets)
            : base(taxBrackets) { }
        #endregion

        #region Consts
        public readonly static ICollection<TaxBracket> USA_SINGLE_TAX_BRACKETS = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = 9275,
                TaxRate = .1M
            },
            new TaxBracket()
            {
                LowerBound = 9275,
                UpperBound = 37650,
                TaxRate = .15M
            },
            new TaxBracket()
            {
                LowerBound = 37650,
                UpperBound = 91150,
                TaxRate = .25M
            },
            new TaxBracket()
            {
                LowerBound = 91150,
                UpperBound = 190150,
                TaxRate = .28M
            },
            new TaxBracket()
            {
                LowerBound = 190150,
                UpperBound = 413350,
                TaxRate = .33M
            },
            new TaxBracket()
            {
                LowerBound = 413350,
                UpperBound = 415050,
                TaxRate = .35M
            },
            new TaxBracket()
            {
                LowerBound = 415050,
                UpperBound = decimal.MaxValue,
                TaxRate = .396M
            }
        };
        #endregion
    }
}
