using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class SalaryAsset : Asset
    {
        protected override decimal CalculateTaxedAmount(YearEndValue yearEndValue)
        {
            var taxableAmount = yearEndValue.StartingValue + yearEndValue.GrowthAmount;
            var deductionAmount = 0;
            return TaxCalculators.Sum(calc => calc.CalculateTax(taxableAmount, deductionAmount));
        }

        protected override decimal CalculateGrowthAmount(YearEndValue yearEndValue)
        {
            // salaries grow at year end so, the remove the first year's growth
            if (yearEndValue.Year == StartingYear)
            {
                return 0;
            }

            return base.CalculateGrowthAmount(yearEndValue);
        }

        protected override decimal CalculateEndingValue(YearEndValue yearEndValue)
        {
            return yearEndValue.StartingValue + yearEndValue.GrowthAmount + yearEndValue.ContributionAmount;
        }
    }
}
