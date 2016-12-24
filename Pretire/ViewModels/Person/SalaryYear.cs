using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Person
{
    public class SalaryYear
    {
        public int Year { get; set; }
        public decimal BaseIncome { get; set; }
        public decimal ContributionTo401k { get; set; }
        public decimal TaxesPaid { get; set; }
        public decimal SocialSecurityPaid { get; set; }
        public decimal MedicarePaid { get; set; }
        public decimal RemainingIncome { get; set; }
    }
}