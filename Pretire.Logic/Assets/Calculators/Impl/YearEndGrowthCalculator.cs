using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class YearEndGrowthCalculator : IGrowthCalculator
    {
        public string Description
        {
            get
            {
                return "Year End";
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
            return startingValue * _growthRate;
        }

        public YearEndGrowthCalculator(decimal growthRate)
        {
            _growthRate = growthRate;
        }

        private decimal _growthRate;
    }
}
