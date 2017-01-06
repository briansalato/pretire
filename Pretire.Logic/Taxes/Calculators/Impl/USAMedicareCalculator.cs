using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class USAMedicareCalculator : TieredTaxBracketCalculator
    {
        public USAMedicareCalculator() :
            base(PremadeTaxBrackets.USA_MEDICARE, false)  {}
    }
}
