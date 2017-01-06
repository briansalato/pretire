using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class NoGrowthCalculator : IGrowthCalculator
    {
        public decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution)
        {
            return 0;
        }
    }
}
