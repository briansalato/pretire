using Pretire.Logic.Calculators;
using Pretire.Logic.Retirement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Models
{
    public class InvestmentAccount401k
    {
        public decimal StartingValue { get; set; }
        public int StartingYear { get; set; }
        public decimal GrowthRate { get; set; }
        public TypeOf401k Type { get; set; }
        public IRetirementCalculator ContributionCalculator { get; set; }
    }
}
