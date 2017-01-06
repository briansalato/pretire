using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class USASocialSecurityCalculator :TieredTaxBracket
    {
        public override decimal CalculateTax(decimal amount, decimal deductions)
        {
            return base.CalculateTax(amount, 0);
        }

        public USASocialSecurityCalculator() :
            base(TaxBrackets.USA_SOCIAL_SECURITY)  {}
    }
}
