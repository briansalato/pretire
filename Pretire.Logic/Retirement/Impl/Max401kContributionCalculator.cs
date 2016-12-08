using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Retirement.Impl
{
    public class Max401kContributionCalculator : IRetirementCalculator
    {
        public decimal CalculateContribution(decimal thisYearsIncome, decimal firstYearsContribution, decimal yearlyGrowthRate, int numberOfYears)
        {
            throw new NotImplementedException();
        }

        #region Singleton
        private Max401kContributionCalculator() { }

        private Max401kContributionCalculator _instance;
        public Max401kContributionCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Max401kContributionCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
