using Pretire.Data.Models;
using Pretire.Logic.Assets.Calculators;
using Pretire.Logic.Assets.Calculators.Impl;
using Pretire.Logic.Assets.Models;
using Pretire.Logic.Taxes.Calculators;
using Pretire.Logic.Taxes.Calculators.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class SalaryConverter
    {
        public static SalaryAsset ToDomainModel(this SalaryEntity entity)
        {
            var domainModel = new SalaryAsset();

            domainModel.Id = entity.Id;
            domainModel.IsActive = entity.IsActive;
            domainModel.StartingValue = entity.StartingValue;
            domainModel.StartingYear = entity.StartingYear;
            domainModel.EndingYear = entity.EndingYear.HasValue ? entity.EndingYear.Value : int.MaxValue;
            domainModel.Name = entity.Name;
            domainModel.GrowthCalculator = entity.GrowthType.ToDomainModel(entity.GrowthRate);
            domainModel.TaxCalculators = entity.TaxCodes.Select(taxCode => taxCode.ToDomainModel()).ToList();

            return domainModel;
        }
    }
}
