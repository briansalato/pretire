using Pretire.Logic.Calculators;
using Pretire.Logic.Calculators.Impl;
using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Retirement.Impl
{
    public class FlatAmountFlatGrowth401kCalculator : Abstract401kCalculator
    {
        protected override decimal CalculateUncheckedContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears)
        {
            return _growthCalculator.CalculateValue(firstYearsContribution, yearlyGrowthRate, numberOfYears);
        }

        #region Singleton
        private FlatAmountFlatGrowth401kCalculator()
        {
            _growthCalculator = FlatGrowthCalculator.Instance;
        }

        private static FlatAmountFlatGrowth401kCalculator _instance;
        public static FlatAmountFlatGrowth401kCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlatAmountFlatGrowth401kCalculator();
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
