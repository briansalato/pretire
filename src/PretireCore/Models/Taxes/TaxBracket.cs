using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Models.Taxes
{
    public class TaxBracket
    {
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public decimal TaxRate { get; set; }
    }
}
