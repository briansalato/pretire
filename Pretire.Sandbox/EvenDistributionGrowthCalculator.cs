using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    public class EvenDistributionGrowthCalculator : IGrowthCalculator
    {
        public decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution)
        {
            return (startingValue + thisYearsContribution / 2) * _growthRate;
        }

        public EvenDistributionGrowthCalculator(decimal growthRate)
        {
            _growthRate = growthRate;
        }

        private decimal _growthRate;
    }
}
