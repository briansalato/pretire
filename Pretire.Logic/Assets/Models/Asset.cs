using Pretire.Logic.Assets.Calculators;
using Pretire.Logic.Taxes.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal StartingValue { get; set; }
        public int StartingYear { get; set; }
        public int EndingYear { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ITaxCalculator> TaxCalculators { get; set; }
        public IContributionCalculator ContributionCalculator { get; set; }
        public IGrowthCalculator GrowthCalculator { get; set; }

        public YearlySummary CalculateValue(int year)
        {
            if (!_yearCache.ContainsKey(year))
            {
                var yearlySummary = new YearlySummary();
                yearlySummary.Year = year;
                if (!IsActive || year < StartingYear || year > EndingYear)
                {
                    yearlySummary.StartingValue = 0;
                    yearlySummary.TaxedAmount = 0;
                    yearlySummary.GrowthAmount = 0;
                    yearlySummary.ContributionAmount = 0;
                    yearlySummary.EndingValue = 0;
                }
                else
                {
                    yearlySummary.StartingValue = CalculateStartingValue(yearlySummary);
                    yearlySummary.ContributionAmount = CalculateContributionAmount(yearlySummary);
                    yearlySummary.GrowthAmount = CalculateGrowthAmount(yearlySummary);
                    yearlySummary.TaxedAmount = CalculateTaxedAmount(yearlySummary);
                    yearlySummary.EndingValue = CalculateEndingValue(yearlySummary);
                }

                _yearCache.Add(year, yearlySummary);
            }
            return _yearCache[year];
        }

        protected virtual decimal CalculateStartingValue(YearlySummary yearlySummary)
        {
            return yearlySummary.Year == StartingYear ? StartingValue : CalculateValue(yearlySummary.Year - 1).EndingValue;
        }

        protected virtual decimal CalculateContributionAmount(YearlySummary yearlySummary)
        {
            return ContributionCalculator.CalculateForYear(yearlySummary.Year);
        }

        protected virtual decimal CalculateGrowthAmount(YearlySummary yearlySummary)
        {
            return GrowthCalculator.CalculateForYear(yearlySummary.StartingValue, yearlySummary.ContributionAmount);
        }

        protected virtual decimal CalculateTaxedAmount(YearlySummary yearlySummart)
        {
            return TaxCalculators.Sum(calc => calc.CalculateTax(yearlySummart.GrowthAmount, 0));
        }

        protected virtual decimal CalculateEndingValue(YearlySummary yearlySummary)
        {
            return yearlySummary.StartingValue + yearlySummary.GrowthAmount + yearlySummary.ContributionAmount - yearlySummary.TaxedAmount;
        }

        private IDictionary<int, YearlySummary> _yearCache = new Dictionary<int, YearlySummary>();
    }
}
