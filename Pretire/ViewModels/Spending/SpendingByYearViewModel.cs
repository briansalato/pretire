using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Spending
{
    public class SpendingByYearViewModel
    {
        public ICollection<string> CostTypeNames { get; set; }
        public ICollection<CostSummaryYear> YearlyData { get; set; }
    }
}