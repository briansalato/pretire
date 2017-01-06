using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class NoContributionCalculator : IContributionCaculator
    {
        public decimal CalculateForYear(int year)
        {
            return 0;
        }
    }
}
