using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators.Impl
{
    public class NoGrowthCostCalculator : ICostGrowthCalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal grwothRate, int numberOfGrowths)
        {
            return startingValue;
        }

        #region Singleton
        private NoGrowthCostCalculator() { }

        private static NoGrowthCostCalculator _instance;
        public static NoGrowthCostCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NoGrowthCostCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
