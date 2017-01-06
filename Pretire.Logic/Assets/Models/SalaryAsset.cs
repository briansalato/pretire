using Pretire.Logic.Assets.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Models
{
    // TODO: For now i have starting value equal to the salary for the year (with growth over last year) and ending value is post taxes
    public class SalaryAsset : Asset
    {
        public IRetirementContributionCalculator RetirementCalculator { get; set; }

        protected override decimal CalculateStartingValue(YearlySummary yearlySummary)
        {
            if (yearlySummary.Year == StartingYear)
            {
                return StartingValue;
            }
            else
            {
                var lastYearsSalary = CalculateValue(yearlySummary.Year - 1).StartingValue;
                return lastYearsSalary + GrowthCalculator.CalculateForYear(lastYearsSalary, 0);
            }
        }

        protected override decimal CalculateTaxedAmount(YearlySummary yearlySummary)
        {
            var taxableAmount = yearlySummary.StartingValue;
            var deductionAmount = Get401kContribution(yearlySummary);
            return TaxCalculators.Sum(calc => calc.CalculateTax(taxableAmount, deductionAmount));
        }

        protected override decimal CalculateGrowthAmount(YearlySummary yearlySummary)
        {
            // salaries grow at year end so, the remove the first year's growth
            if (yearlySummary.Year == StartingYear)
            {
                return 0;
            }

            return base.CalculateGrowthAmount(yearlySummary);
        }

        protected override decimal CalculateEndingValue(YearlySummary yearlySummary)
        {
            return yearlySummary.StartingValue - Get401kContribution(yearlySummary) - yearlySummary.TaxedAmount;
        }

        private decimal Get401kContribution(YearlySummary yearlySummary)
        {
            var taxableAmount = yearlySummary.StartingValue;
            return RetirementCalculator.CalculateForYear(yearlySummary.Year, taxableAmount);
        }
    }
}
