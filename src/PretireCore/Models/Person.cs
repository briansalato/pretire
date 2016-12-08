using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Models
{
    public class Person
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryGrowthRate { get; set; }
        public int? StartingYear { get; set; }
        public int RetirementAge { get; set; }

        public bool UsePercentage401kContribution { get; set; }
        public bool MaxOut401k { get; set; }
        public decimal ContributionAmountFor401k { get; set;}
    }
}
