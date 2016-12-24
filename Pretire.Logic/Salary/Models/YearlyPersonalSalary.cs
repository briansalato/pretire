using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Salary.Models
{
    public class YearlyPersonalSalary : YearlySalary
    {
        public Person Person { get; set; }
    }
}
