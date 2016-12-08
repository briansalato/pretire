using Pretire.Logic.Income.Models;
using Pretire.ViewModels.Income;
using System.Collections.Generic;
using System.Linq;

namespace Pretire.Builders
{
    public class IncomeBuilder
    {
        public ViewSalariesViewModel BuildSalariesViewModel(ICollection<Person> people, int startYear, int endYear)
        {
            var viewModel = new ViewSalariesViewModel()
            {
                Names = new List<string>(),
                SalariesByYear = new List<ViewModels.Income.SalaryYear>()
            };

            foreach(var person in people)
            {
                viewModel.Names.Add(person.Name);
            }

            for (var year = startYear; year <= endYear; year++)
            {
                var yearlySalary = new ViewModels.Income.SalaryYear()
                {
                    Year = year
                };

                foreach(var person in people.Where(p => p.IsWorking(year)))
                {
                    var salary = person.IncomeCalculator.CalculateValue(person.StartingIncome, person.IncomeGrowthRate, year - person.StartingYear);
                    var contributionTo401k = person.RetirementAccount.ContributionCalculator.CalculateContribution(salary, person.RetirementAccount.StartingValue, person.RetirementAccount.GrowthRate, year - person.RetirementAccount.StartingYear);
                    yearlySalary.BaseIncome += salary;
                    yearlySalary.ContributionTo401k += contributionTo401k;
                    yearlySalary.TaxesPaid += person.IncomeTaxCalculator.CalculateTax(salary, contributionTo401k, 0);
                    yearlySalary.SocialSecurityPaid += person.SocialSecurityCalculator.CalculateTax(salary, contributionTo401k, 0);
                    yearlySalary.MedicarePaid += person.MedicareCalculator.CalculateTax(salary, contributionTo401k, 0);
                    yearlySalary.RemainingIncome = yearlySalary.BaseIncome - yearlySalary.ContributionTo401k - yearlySalary.TaxesPaid - yearlySalary.SocialSecurityPaid - yearlySalary.MedicarePaid;
                }

                viewModel.SalariesByYear.Add(yearlySalary);
            }
            

            return viewModel;
        }
    }
}