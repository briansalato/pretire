using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Retirement
{
    public interface IRetirementCalculator
    {
        decimal CalculateContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears);
    }
}
