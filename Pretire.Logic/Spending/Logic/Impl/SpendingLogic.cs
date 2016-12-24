using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretire.Logic.Spending.Models;

namespace Pretire.Logic.Spending.Logic.Impl
{
    public class SpendingLogic : ISpendingLogic
    {
        public ICollection<YearlyItemCost> GetYearlySpendingByItem(ICollection<CostItem> costs, int startYear, int endYear)
        {
            var yearlyCosts = new List<YearlyItemCost>();

            for (var year = startYear; year <= endYear; year++)
            {
                foreach (var costItem in costs)
                {
                    yearlyCosts.Add(new YearlyItemCost()
                    {
                        Year = year,
                        Cost = costItem,
                        AmountSpent = costItem.CalculateCostForYear(year)
                    });
                }
            }
            return yearlyCosts;
        }
    }
}
