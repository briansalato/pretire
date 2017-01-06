using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class USASingleTaxCalculator : TieredTaxBracket
    {
        public USASingleTaxCalculator() :
            base(TaxBrackets.USA_SINGLE_INCOME_TAX) {}

    }
}
