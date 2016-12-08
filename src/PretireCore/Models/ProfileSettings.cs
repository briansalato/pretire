using Pretire.Models.Taxes;
using System;
using System.Collections.Generic;

namespace Pretire.Models
{
    public class ProfileSettings
    {
        public int StartingYear
        {
            get
            {
                return DateTime.Now.Year;
            }
        }
        public int EndingYear
        {
            get
            {
                return StartingYear + 30;
            }
        }

        // Tax Settings
        public ICollection<TaxBracket> TaxBrackets { get; set; }
        public decimal MedicareRate { get; set; }
        public decimal SocialSecurityRate { get; set; }

        // 401k Settings
        public decimal MaxYearly401kContribution { get; set; }
        public decimal MaxYearly401kContributionGrowth { get; set; }
    }
}