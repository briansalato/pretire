using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators.Impl
{
    public class NoGrowthCalculator : ICalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal grwothRate, int numberOfGrowths)
        {
            return startingValue;
        }

        #region Singleton
        private NoGrowthCalculator() { }

        private static NoGrowthCalculator _instance;
        public static NoGrowthCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NoGrowthCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
