using Pretire.Logic.Assets.Models;
using Pretire.ViewModels.Salary;
using System.Collections.Generic;
using System.Linq;

namespace Pretire.Builders
{
    public class SalaryBuilder
    {
        public ICollection<SalarySummaryViewModel> BuildSalarySummaryViewModel(IEnumerable<SalaryAsset> salaries)
        {
            return salaries
                .Select(s => new SalarySummaryViewModel(s))
                .ToList();
        }

        public ViewSalariesViewModel BuildSalariesViewModel(IEnumerable<SalaryAsset> salaries, int startYear, int endYear)
        {
            var viewModel = new ViewSalariesViewModel()
            {
                Names = new List<string>(),
                SalariesByYear = new List<SalaryYear>()
            };

            foreach(var person in salaries)
            {
                viewModel.Names.Add(person.Name);
            }

            for (var year = startYear; year <= endYear; year++)
            {
                var yearlySalary = new SalaryYear()
                {
                    Year = year
                };

                foreach(var salary in salaries)
                {
                    var yearData = salary.CalculateValue(year);

                    //var salary = person.IncomeCalculator.CalculateValue(person.StartingIncome, person.IncomeGrowthRate, year - person.StartingYear);
                    //var contributionTo401k = person.RetirementAccount.ContributionCalculator.CalculateContribution(salary, person.RetirementAccount.StartingContribution, person.RetirementAccount.GrowthRate, year - person.RetirementAccount.StartingYear);
                    yearlySalary.BaseIncome += yearData.StartingValue;
                    yearlySalary.ContributionTo401k += salary.RetirementCalculator.CalculateForYear(year, yearData.EndingValue);
                    yearlySalary.TaxesPaid += yearData.TaxedAmount;
                    yearlySalary.RemainingIncome = yearData.EndingValue;
                }

                viewModel.SalariesByYear.Add(yearlySalary);

            }
            

            return viewModel;
        }
    }
}