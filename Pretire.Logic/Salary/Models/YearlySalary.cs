namespace Pretire.Logic.Salary.Models
{
    public class YearlySalary
    {
        public int Year { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal ContributionTo401k { get; set; }
        public decimal IncomeTaxPaid { get; set; }
        public decimal SocialSecurityPaid { get; set; }
        public decimal MedicarePaid { get; set; }
        public decimal RemainingSalary
        {
            get
            {
                return BaseSalary - ContributionTo401k - IncomeTaxPaid - SocialSecurityPaid - MedicarePaid;
            }
        }
    }
}