using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators.Impl
{
    public class FlatGrowthCostCalculator : ICostGrowthCalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal growthRate, int numberOfGrowths)
        {
            return startingValue + growthRate * numberOfGrowths;
        }
        
        #region Singleton
        private FlatGrowthCostCalculator() { }

        private static FlatGrowthCostCalculator _instance;
        public static FlatGrowthCostCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlatGrowthCostCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
