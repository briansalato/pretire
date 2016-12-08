using Pretire.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators.Impl
{
    public class PercentGrowthCalculator : ICalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal growthRate, int numberOfGrowths)
        {
            return startingValue * MathHelper.Pow(1 + growthRate, numberOfGrowths);
        }

        #region Singleton
        private PercentGrowthCalculator() { }

        private static PercentGrowthCalculator _instance;
        public static PercentGrowthCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PercentGrowthCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
