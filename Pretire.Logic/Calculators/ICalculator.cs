using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Calculators
{
    public interface ICalculator
    {
        decimal CalculateValue(decimal startingValue, decimal growthRate, int numberOfGrowths);
    }
}
