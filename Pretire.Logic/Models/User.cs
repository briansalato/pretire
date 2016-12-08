using Pretire.Logic.Income.Models;
using Pretire.Logic.Spending.Models;
using System.Collections.Generic;

namespace Pretire.Logic.Models
{
    public class User
    {
        public ICollection<Person> People { get; set; }
        public ICollection<Cost> Costs { get; set; }
    }
}
