using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Calculators.Impl
{
    public class NoRetirementContributionCalculator : IRetirementContributionCalculator
    {
        public decimal CalculateForYear(int year, decimal yearlySalary)
        {
            return 0;
        }
    }
}
