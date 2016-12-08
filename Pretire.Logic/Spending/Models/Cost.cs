using Pretire.Logic.Calculators;

namespace Pretire.Logic.Spending.Models
{
    public class Cost
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal YearlyPaymentAmount { get; set; }
        public decimal YearlyGrowthRate { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsActive { get; set; }
        public decimal RetirementFactor { get; set; }
        public ICalculator GrowthCalculator { get; set; }

        public decimal CalculateCostForYear(int year)
        {
            if (year >= StartYear && year <= EndYear)
            {
                return GrowthCalculator.CalculateValue(YearlyPaymentAmount, YearlyGrowthRate, year - StartYear);
            }
            else
            {
                return 0;
            }
        }
    }
}
