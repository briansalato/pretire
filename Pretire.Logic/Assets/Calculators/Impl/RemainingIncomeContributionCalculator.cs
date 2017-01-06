using Pretire.Logic.Assets.Models;
using Pretire.Logic.Spending.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class RemainingIncomeContributionCalculator : IContributionCalculator
    {
        public decimal CalculateForYear(int year)
        {
            var totalIncome = _income.Sum(i => i.CalculateValue(year).EndingValue);
            var totalSpend = _spending.Sum(s => s.CalculateCostForYear(year));
            return (totalIncome - totalSpend) * _percentage;
        }

        public RemainingIncomeContributionCalculator(ICollection<Asset> income, ICollection<CostItem> spending, decimal percentage)
        {
            _income = income;
            _spending = spending;
            _percentage = percentage;
        }

        private ICollection<Asset> _income;
        private ICollection<CostItem> _spending;
        private decimal _percentage;
    }
}
