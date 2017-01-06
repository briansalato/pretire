using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Spending
{
    public class CostByYearsViewModel
    {
        public string Name { get; set; }
        public ICollection<YearlyAmount> YearlyValues { get; set; }
    }
}