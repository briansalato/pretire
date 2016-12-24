using Pretire.Logic.Assets.Models;
using Pretire.Logic.Calculators;
using Pretire.Logic.Retirement;
using Pretire.Logic.Taxes.Calculators;

namespace Pretire.Logic.Salary.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int RetirementAge { get; set; }
        public decimal StartingIncome { get; set; }
        public decimal IncomeGrowthRate { get; set; }
        public int StartingYear { get; set; }
        public ICalculator IncomeCalculator { get; set; }
        public InvestmentAccount401k RetirementAccount { get; set; }
        public IIncomeTaxCalculator IncomeTaxCalculator { get; set; }
        public IIncomeTaxCalculator SocialSecurityCalculator { get; set; }
        public IIncomeTaxCalculator MedicareCalculator { get; set; }

        public bool IsWorking(int year)
        {
            return year >= StartingYear && year <= RetirementYear;
        }

        protected int RetirementYear
        {
            get
            {
                return BirthYear + RetirementAge;
            }
        }
    }
}