using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class NoGrowthCalculator : IGrowthCalculator
    {
        public string Description
        {
            get
            {
                return "No Growth";
            }
        }

        public decimal YearlyGrowthRate
        {
            get
            {
                return 0;
            }
        }

        public decimal CalculateForYear(decimal startingValue, decimal thisYearsContribution)
        {
            return 0;
        }
    }
}
