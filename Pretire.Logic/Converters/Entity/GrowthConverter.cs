using Pretire.Data.Models;
using Pretire.Logic.Assets.Calculators;
using Pretire.Logic.Assets.Calculators.Impl;
using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class GrowthConverter
    {
        public static IGrowthCalculator ToDomainModel(this GrowthTypeEntity entity, decimal growthRate)
        {
            var growthType = (GrowthType)entity.Id;
            return growthType.ToDomainModel(growthRate);
        }
    }
}
