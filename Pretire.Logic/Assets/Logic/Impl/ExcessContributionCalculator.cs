using Pretire.Logic.Salary.Logic;
using Pretire.Logic.Salary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Logic.Impl
{
    public class ExcessContributionCalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal contributionAmount, decimal growthRate)
        {
            var value = startingValue;
            return (startingValue * (1 + growthRate)) + (contributionAmount * (1 + growthRate / 2));
        }

        public ExcessContributionCalculator(ICollection<Person> salaries, decimal excessContributionPercentage)
        {
            _salaries = salaries;
            _excessContributionPercentage = excessContributionPercentage;
        }
        
        private ISalaryLogic _salaryLogic;
        private ICollection<Person> _salaries;
        private decimal _excessContributionPercentage;
    }
}
