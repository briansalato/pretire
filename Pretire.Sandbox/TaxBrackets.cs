using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    static class TaxBrackets
    {
        public readonly static ICollection<TaxBracket> USA_SOCIAL_SECURITY = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = 118500,
                TaxRate = .062M
            },
            new TaxBracket()
            {
                LowerBound = 118500,
                UpperBound = decimal.MaxValue,
                TaxRate = 0
            }
        };

        public readonly static ICollection<TaxBracket> USA_MEDICARE = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = decimal.MaxValue,
                TaxRate = .0145M
            }
        };

        public readonly static ICollection<TaxBracket> USA_SINGLE_INCOME_TAX = new List<TaxBracket>()
        {
            new TaxBracket()
            {
                LowerBound = 0,
                UpperBound = 9275,
                TaxRate = .1M
            },
            new TaxBracket()
            {
                LowerBound = 9275,
                UpperBound = 37650,
                TaxRate = .15M
            },
            new TaxBracket()
            {
                LowerBound = 37650,
                UpperBound = 91150,
                TaxRate = .25M
            },
            new TaxBracket()
            {
                LowerBound = 91150,
                UpperBound = 190150,
                TaxRate = .28M
            },
            new TaxBracket()
            {
                LowerBound = 190150,
                UpperBound = 413350,
                TaxRate = .33M
            },
            new TaxBracket()
            {
                LowerBound = 413350,
                UpperBound = 415050,
                TaxRate = .35M
            },
            new TaxBracket()
            {
                LowerBound = 415050,
                UpperBound = decimal.MaxValue,
                TaxRate = .396M
            }
        };
    }
}
