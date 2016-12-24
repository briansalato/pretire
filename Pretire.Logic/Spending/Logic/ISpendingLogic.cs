using Pretire.Logic.Spending.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Spending.Logic
{
    public interface ISpendingLogic
    {
        ICollection<YearlyItemCost> GetYearlySpendingByItem(ICollection<CostItem> costs, int startYear, int endYear);
    }
}
