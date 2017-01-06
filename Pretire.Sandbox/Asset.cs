using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    public class Asset
    {
        public string Name { get; set; }
        public decimal StartingValue { get; set; }
        public int StartingYear { get; set; }
        public int EndingYear { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ITaxCalculator> TaxCalculators { get; set; }
        public IContributionCaculator ContributionCalculator { get; set; }
        public IGrowthCalculator GrowthCalculator { get; set; }

        public YearEndValue CalculateValue(int year)
        {
            if (!_yearCache.ContainsKey(year))
            {
                YearEndValue yearEndValue = new YearEndValue();
                yearEndValue.Year = year;
                if (!IsActive || year < StartingYear || year > EndingYear)
                {
                    yearEndValue.StartingValue = 0;
                    yearEndValue.TaxedAmount = 0;
                    yearEndValue.GrowthAmount = 0;
                    yearEndValue.ContributionAmount = 0;
                    yearEndValue.EndingValue = 0;
                }
                else
                {
                    yearEndValue.StartingValue = CalculateStartingValue(yearEndValue);
                    yearEndValue.ContributionAmount = CalculateContributionAmount(yearEndValue);
                    yearEndValue.GrowthAmount = CalculateGrowthAmount(yearEndValue);
                    yearEndValue.TaxedAmount = CalculateTaxedAmount(yearEndValue);
                    yearEndValue.EndingValue = CalculateEndingValue(yearEndValue);
                }

                _yearCache.Add(year, yearEndValue);
            }
            return _yearCache[year];
        }

        protected virtual decimal CalculateStartingValue(YearEndValue yearEndValue)
        {
            return yearEndValue.Year == StartingYear ? StartingValue : CalculateValue(yearEndValue.Year - 1).EndingValue;
        }

        protected virtual decimal CalculateContributionAmount(YearEndValue yearEndValue)
        {
            return ContributionCalculator.CalculateForYear(yearEndValue.Year);
        }

        protected virtual decimal CalculateGrowthAmount(YearEndValue yearEndValue)
        {
            return GrowthCalculator.CalculateForYear(yearEndValue.StartingValue, yearEndValue.ContributionAmount);
        }

        protected virtual decimal CalculateTaxedAmount(YearEndValue yearEndValue)
        {
            return TaxCalculators.Sum(calc => calc.CalculateTax(yearEndValue.GrowthAmount, 0));
        }

        protected virtual decimal CalculateEndingValue(YearEndValue yearEndValue)
        {
            return yearEndValue.StartingValue + yearEndValue.GrowthAmount + yearEndValue.ContributionAmount - yearEndValue.TaxedAmount;
        }

        private IDictionary<int, YearEndValue> _yearCache = new Dictionary<int, YearEndValue>();
    }
}
