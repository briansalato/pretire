using Pretire.Logic.Salary.Models;
using Pretire.Logic.Spending.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Models
{
    public class User
    {
        public ICollection<Person> People { get; set; }
        public ICollection<CostItem> Costs { get; set; }
    }
}
