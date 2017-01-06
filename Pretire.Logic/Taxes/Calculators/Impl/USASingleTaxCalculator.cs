using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class USASingleTaxCalculator : TieredTaxBracketCalculator
    {
        public USASingleTaxCalculator() :
            base(PremadeTaxBrackets.USA_SINGLE_INCOME_TAX, true) {}

    }
}
