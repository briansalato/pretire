using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class EvenDistributionGrowthCalculator : IGrowthCalculator
    {
        public string Description
        {
            get
            {
                return "Even Distribution";
            }
        }

        public decimal YearlyGrowthRate
        {
            get
            {
                return _growthRate;
            }
        }
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
