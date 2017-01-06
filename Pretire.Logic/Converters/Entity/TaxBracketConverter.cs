using Pretire.Data.Models;
using Pretire.Logic.Taxes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Converters.Entity
{
    public static class TaxBracketConverter
    {
        public static TaxBracket ToDomainModel(this TaxBracketEntity entity)
        {
            var domainModel = new TaxBracket();
            domainModel.TaxRate = entity.TaxRate;
            domainModel.LowerBound = entity.LowerBound;
            domainModel.UpperBound = entity.UpperBound.HasValue ? entity.UpperBound.Value : decimal.MaxValue;
            return domainModel;
        }
    }
}
