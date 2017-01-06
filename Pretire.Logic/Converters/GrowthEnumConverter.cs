using Pretire.Data.Models;
using Pretire.Logic.Assets.Calculators;
using Pretire.Logic.Assets.Calculators.Impl;
using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters
{
    public static class GrowthEnumConverter
    {
        public static IGrowthCalculator ToDomainModel(this GrowthType growthType, decimal growthRate)
        {
            switch (growthType)
            {
                case GrowthType.FlatAmount:
                    return new EvenDistributionGrowthCalculator(growthRate);
                case GrowthType.Percentage:
                    return new YearEndGrowthCalculator(growthRate);
                case GrowthType.None:
                default:
                    return new NoGrowthCalculator();
            }
        }
    }
}
