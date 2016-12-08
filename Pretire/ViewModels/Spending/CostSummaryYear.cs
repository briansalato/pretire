using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Spending
{
    public class CostSummaryYear
    {
        public int Year { get; set; }
        public IDictionary<string, decimal> CostTotalByType { get; set; }
        public decimal CostTotal { get; set; }
    }
}