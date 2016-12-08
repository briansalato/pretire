using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Models
{
    public class Account401k : InvestmentAccount
    {
        public Account401kType Type { get; set; }
        public decimal CompanyMatchPercentage { get; set; }
    }
}
