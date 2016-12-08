using Pretire.Logic.Taxes.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class SocialSecurityCalculator : FICAIncomeTaxCalculator
    {
        #region Constructors
        public SocialSecurityCalculator()
            :base(USA_SS_TAX_BRACKETS) { }
        #endregion

        #region Consts
        private static ICollection<TaxBracket> USA_SS_TAX_BRACKETS = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = 118500,
                TaxRate = .062M
            },
            new TaxBracket()
            {
                LowerBound = 118500,
                UpperBound = decimal.MaxValue,
                TaxRate = 0
            }
        };
        #endregion
    }
}
