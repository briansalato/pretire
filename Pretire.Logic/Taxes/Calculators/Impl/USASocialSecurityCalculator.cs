using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class USASocialSecurityCalculator : TieredTaxBracketCalculator
    {
        public USASocialSecurityCalculator() :
            base(PremadeTaxBrackets.USA_SOCIAL_SECURITY, false)  {}
    }
}
