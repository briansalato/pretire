using Pretire.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators.Impl
{
    public class FlatGrowthCalculator : ICalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal growthRate, int numberOfGrowths)
        {
            return startingValue + growthRate * numberOfGrowths;
        }
        
        #region Singleton
        private FlatGrowthCalculator() { }

        private static FlatGrowthCalculator _instance;
        public static FlatGrowthCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FlatGrowthCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
