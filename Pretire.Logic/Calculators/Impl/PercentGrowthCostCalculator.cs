using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brian.Common.Math;

namespace Pretire.Logic.Calculators.Impl
{
    public class PercentGrowthCostCalculator : ICostGrowthCalculator
    {
        public decimal CalculateValue(decimal startingValue, decimal growthRate, int numberOfGrowths)
        {
            return startingValue * MathHelper.Pow(1 + growthRate, numberOfGrowths);
        }

        #region Singleton
        private PercentGrowthCostCalculator() { }

        private static PercentGrowthCostCalculator _instance;
        public static PercentGrowthCostCalculator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PercentGrowthCostCalculator();
                }
                return _instance;
            }
        }
        #endregion
    }
}
