using Pretire.Helpers;
using Pretire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Logic.Impl
{
    public class IncomeLogic : IIncomeLogic
    {
        public void GetYearlySalaries(ICollection<Person> people, int startingYear, object endingYear)
        {
            throw new NotImplementedException();
        }

        public ICollection<IncomeYear> CalculateIncomeYears(Person person, int startYear, int endYear)
        {
            var years = new List<IncomeYear>();
            for(int year = startYear; year <= endYear; year++)
            {
                years.Add(CalculateIncomeYear(person, year));
            }
            return years;
        }

        private IncomeYear CalculateIncomeYear(Person person, int year)
        {
            var incomeYear = new IncomeYear()
            {
                Year = year,
                Income = person.Salary * MathHelper.Pow(1 + person.SalaryGrowthRate, year - _profileSettings.StartingYear)
            };

            incomeYear.ContributionTo401k = _401kLogic.Calculate401kContribution(person, year, incomeYear.Income);

            var taxableIncome = incomeYear.Income - incomeYear.ContributionTo401k;
            incomeYear.TaxesPaid = _taxLogic.CalculateIncomeTax(taxableIncome, _profileSettings.TaxBrackets);
            incomeYear.SocialSecurityPaid = taxableIncome * _profileSettings.SocialSecurityRate;
            incomeYear.MedicarePaid = taxableIncome * _profileSettings.MedicareRate;
            incomeYear.RemainingIncome = incomeYear.Income - incomeYear.ContributionTo401k - incomeYear.TaxesPaid - incomeYear.SocialSecurityPaid - incomeYear.MedicarePaid;

            return incomeYear;
        }

        private TaxLogic _taxLogic;
        private ProfileSettings _profileSettings;
        private a401kLogic _401kLogic;
    }
}
