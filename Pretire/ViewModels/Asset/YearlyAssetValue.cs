using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Asset
{
    public class YearlyAssetValue
    {
        public int Year { get; set; }
        public decimal StartingValue { get; set; }
        public decimal AmountContributed { get; set; }
        public decimal AmountGrown { get; set; }
        public decimal EndingValue { get; set; }
    }
}