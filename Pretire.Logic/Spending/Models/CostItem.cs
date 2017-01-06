using Pretire.Logic.Calculators;

namespace Pretire.Logic.Spending.Models
{
    public class CostItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        //public PaymentType PaymentType { get; set; }
        public decimal YearlyPaymentAmount { get; set; }
        public decimal YearlyGrowthRate { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsActive { get; set; }
        public decimal RetirementFactor { get; set; }
        public ICostGrowthCalculator GrowthCalculator { get; set; }

        //public string DisplayCost
        //{
        //    get
        //    {
        //        string frequency;
        //        decimal paymentAmount;

        //        switch (PaymentType)
        //        {
        //            case PaymentType.Monthly:
        //                frequency = "month";
        //                paymentAmount = YearlyPaymentAmount / 12;
        //                break;
        //            case PaymentType.Yearly:
        //            default:
        //                frequency = "year";
        //                paymentAmount = YearlyPaymentAmount;
        //                break;
        //        }

        //        return paymentAmount.ToString("c") + " / " + frequency;
        //    }
        //}

        public decimal CalculateCostForYear(int year)
        {
            if (IsActive 
                && year >= StartYear 
                && year <= EndYear)
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
