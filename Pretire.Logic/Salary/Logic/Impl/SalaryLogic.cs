using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pretire.Logic.Salary.Models;

namespace Pretire.Logic.Salary.Logic.Impl
{
    public class SalaryLogic : ISalaryLogic
    {
        public ICollection<YearlySalary> GetYearlySalary(ICollection<Person> people, int startYear, int endYear)
        {
            var yearlySalaries = new List<YearlySalary>();
            var salariesByPerson = GetYearlySalaryPerPerson(people, startYear, endYear);
            for(var year = startYear; year <= endYear; year++)
            {
                var currentSalaries = salariesByPerson.Where(p => p.Year == year);
                yearlySalaries.Add(new YearlySalary()
                {
                    Year = year,
                    BaseSalary = currentSalaries.Sum(cy => cy.BaseSalary),
                    ContributionTo401k = currentSalaries.Sum(cy => cy.ContributionTo401k),
                    IncomeTaxPaid = currentSalaries.Sum(cy => cy.IncomeTaxPaid),
                    SocialSecurityPaid = currentSalaries.Sum(cy => cy.SocialSecurityPaid),
                    MedicarePaid = currentSalaries.Sum(cy => cy.MedicarePaid)
                });
            }

            return yearlySalaries;
        }

        public ICollection<YearlyPersonalSalary> GetYearlySalaryPerPerson(ICollection<Person> people, int startYear, int endYear)
        {
            var yearlySalaries = new List<YearlyPersonalSalary>();
            for (var year = startYear; year <= endYear; year++)
            {
                foreach (var person in people)
                {
                    var currentYear = new YearlyPersonalSalary();
                    var salary = person.IncomeCalculator.CalculateValue(person.StartingIncome, person.IncomeGrowthRate, year - person.StartingYear);
                    var contributionTo401k = person.RetirementAccount.ContributionCalculator.CalculateContribution(salary, person.RetirementAccount.StartingContribution, person.RetirementAccount.GrowthRate, year - person.RetirementAccount.StartingYear);
                    currentYear.Person = person;
                    currentYear.Year = year;
                    currentYear.BaseSalary = salary;
                    currentYear.ContributionTo401k = contributionTo401k;
                    currentYear.IncomeTaxPaid += person.IncomeTaxCalculator.CalculateTax(salary, contributionTo401k, 0);
                    currentYear.SocialSecurityPaid += person.SocialSecurityCalculator.CalculateTax(salary, contributionTo401k, 0);
                    currentYear.MedicarePaid += person.MedicareCalculator.CalculateTax(salary, contributionTo401k, 0);

                    yearlySalaries.Add(currentYear);
                }
            }

            return yearlySalaries;
        }
    }
}
