using Pretire.Logic.Spending.Models;
using Pretire.ViewModels;
using Pretire.ViewModels.Spending;
using System.Collections.Generic;
using System.Linq;

namespace Pretire.Builders
{
    public class SpendingBuilder
    {
        public SpendingByYearViewModel BuildSpendingByYearViewModel(ICollection<CostItem> costs, int startYear, int endYear)
        {
            var viewModel = new SpendingByYearViewModel();
            viewModel.CostTypeNames = costs.Select(c => c.Type).Distinct().ToList();
            viewModel.YearlyData = new List<CostSummaryYear>();

            for (var year = startYear; year <= endYear; year++)
            {
                var yearData = new CostSummaryYear();
                yearData.Year = year;
                yearData.CostTotalByType = costs
                    .GroupBy(g => g.Type)
                    .Select(group => new {
                        Type = group.Key,
                        Total = group.Sum(cost => cost.CalculateCostForYear(year))
                    }).ToDictionary(result => result.Type, result => result.Total);
                yearData.CostTotal = yearData.CostTotalByType.Sum(type => type.Value);

                viewModel.YearlyData.Add(yearData);
            }
            return viewModel;
        }

        public CostByYearsViewModel BuildCostByYearViewModel(CostItem cost, int startYear, int endYear)
        {
            var viewModel = new CostByYearsViewModel();
            viewModel.Name = cost.Name;
            viewModel.YearlyValues = new List<YearlyAmount>();
            for (var year = startYear; year <= endYear; year++)
            {
                viewModel.YearlyValues.Add(new YearlyAmount()
                {
                    Year = year,
                    Amount = cost.CalculateCostForYear(year)
                });
            }

            return viewModel;
        }
    }
}