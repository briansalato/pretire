using Pretire.Logic.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Models
{
    public class InvestmentAccount
    {
        public string Name { get; set; }
        public int StartingYear { get; set; }
        public decimal StartingValue { get; set; }
        public decimal GrowthRate { get; set; }
        public decimal ExcessIncomeContributionRate { get; set; }
        public ICalculator GrowthCalculator { get; set; }
    }
}
