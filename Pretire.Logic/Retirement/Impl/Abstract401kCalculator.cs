using System;

namespace Pretire.Logic.Retirement.Impl
{
    public abstract class Abstract401kCalculator : IRetirementCalculator
    {
        public decimal CalculateContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears)
        {
            return Math.Min(thisYearsIncome, CalculateUncheckedContribution(thisYearsIncome, firstYearsContribution, yearlyGrowthRate, numberOfYears));
        }

        protected abstract decimal CalculateUncheckedContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears);
    }
}
