using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Spending.Models
{
    public class YearlyItemCost
    {
        public int Year { get; set; }
        public CostItem Cost { get; set; }
        public decimal AmountSpent { get; set; }
    }
}
