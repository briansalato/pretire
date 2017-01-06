using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators.Impl
{
    public class USACapitalGainsCalculator : ITaxCalculator
    {
        public decimal CalculateTax(decimal amount, decimal deductions)
        {
            return amount * .15M;
        }
    }
}
