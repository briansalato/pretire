using Pretire.Logic.Calculators;
using Pretire.Logic.Calculators.Impl;
using Pretire.Logic.Helpers;
using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Retirement.Impl
{
    public class PercentageRatePercentageGrowth401kCalculator : Abstract401kCalculator
    {
        protected override decimal CalculateUncheckedContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears)
        {
            return thisYearsIncome * _growthCalculator.CalculateValue(firstYearsContribution, yearlyGrowthRate, numberOfYears);
        }

        #region Singleton
        private PercentageRatePercentageGrowth401kCalculator()
        {
            _growthCalculator = PercentGrowthCalculator.Instance;
        }

        private static PercentageRatePercentageGrowth401kCalculator _instance;
        public static PercentageRatePercentageGrowth401kCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PercentageRatePercentageGrowth401kCalculator();
                }
                return _instance;
            }
        }
        #endregion

        #region Private Variables
        private static ICalculator _growthCalculator;
        #endregion
    }
}
