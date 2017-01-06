using Pretire.Data.Models;
using Pretire.Logic.Taxes.Calculators;
using Pretire.Logic.Taxes.Calculators.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class TaxCodeConverter
    {
        public static ITaxCalculator ToDomainModel(this TaxCodeEntity entity)
        {
            return new TieredTaxBracketCalculator(
                entity.Brackets.Select(bracket => bracket.ToDomainModel()).ToList()
                , entity.UsesDeductions
            );
        }
    }
}
