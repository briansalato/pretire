using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Models
{
    public class IncomeYear
    {
        public int Year { get; set; }
        public decimal Income { get; set; }
        public decimal ContributionTo401k { get; set; }
        public decimal TaxesPaid { get; set; }
        public decimal SocialSecurityPaid { get; set; }
        public decimal MedicarePaid { get; set; }
        public decimal RemainingIncome { get; set; }
    }
}
