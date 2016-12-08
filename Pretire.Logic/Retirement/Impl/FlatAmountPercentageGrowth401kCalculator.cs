using Pretire.Logic.Calculators;
using Pretire.Logic.Calculators.Impl;
using Pretire.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Retirement.Impl
{
    public class FlatAmountPercentageGrowth401kCalculator : Abstract401kCalculator
    {
        protected override decimal CalculateUncheckedContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears)
        {
            return _growthCalculator.CalculateValue(firstYearsContribution, yearlyGrowthRate, numberOfYears);
        }

        #region Singleton
        private FlatAmountPercentageGrowth401kCalculator()
        {
            _growthCalculator = PercentGrowthCalculator.Instance;
        }

        private static FlatAmountPercentageGrowth401kCalculator _instance;
        public static FlatAmountPercentageGrowth401kCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlatAmountPercentageGrowth401kCalculator();
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
