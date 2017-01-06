using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class Max401kContributionCalculator : IRetirementContributionCalculator
    {
        public decimal CalculateForYear(int year, decimal yearlySalary)
        {
            // Can't contribute more than you make
            return Math.Min(_maxContribution, yearlySalary);
        }

        private decimal _maxContribution = 18000;
    }
}
