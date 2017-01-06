using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    public class EndOfYearGrowthCalculator : IGrowthCalculator
    {
        public decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution)
        {
            return startingValue * _growthRate;
        }

        public EndOfYearGrowthCalculator(decimal growthRate)
        {
            _growthRate = growthRate;
        }

        private decimal _growthRate;
    }
}
