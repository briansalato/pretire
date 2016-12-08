using Pretire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretire.Logic
{
    public class a401kLogic
    {
        public decimal Calculate401kContribution(Person person, int year, decimal income)
        {
            decimal contribution;
            var max401kContribution = CalculateMaxContribution(year);
            if (person.MaxOut401k)
            {
                contribution = max401kContribution;
            }
            else if (person.UsePercentage401kContribution)
            {
                contribution = Math.Min(max401kContribution, income * person.ContributionAmountFor401k);
            }
            else
            {
                contribution = Math.Min(max401kContribution, person.ContributionAmountFor401k);
            }

            return contribution;
        }

        private decimal CalculateMaxContribution(int year)
        {
            return _profileSettings.MaxYearly401kContribution * (year - _profileSettings.StartingYear) * _profileSettings.MaxYearly401kContributionGrowth;
        }

        private ProfileSettings _profileSettings;
    }
}
