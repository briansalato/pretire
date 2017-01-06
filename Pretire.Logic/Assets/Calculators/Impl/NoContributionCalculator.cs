using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class NoContributionCalculator : IContributionCalculator
    {
        public decimal CalculateForYear(int year)
        {
            return 0;
        }
    }
}
