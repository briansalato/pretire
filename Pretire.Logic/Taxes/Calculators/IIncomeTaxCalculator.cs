using Pretire.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Taxes.Calculators
{
    public interface IIncomeTaxCalculator
    {
        decimal CalculateTax(decimal salary, decimal contributionTo401k, decimal deductionAmount);
    }
}