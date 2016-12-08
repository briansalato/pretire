using Pretire.Logic.Taxes.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class MedicareCalculator : FICAIncomeTaxCalculator
    {
        #region Constructors
        public MedicareCalculator()
            :base(USA_MEDICARE_TAX_BRACKETS) { }
        #endregion

        #region Consts
        public readonly static ICollection<TaxBracket> USA_MEDICARE_TAX_BRACKETS = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = decimal.MaxValue,
                TaxRate = .0145M
            }
        };
        #endregion
    }
}
