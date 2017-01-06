using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Salary
{
    public enum ContributionTo401kType
    {
        [Display(Name = "No Contribution")] None,
        [Display(Name = "Flat Dollar Amount")] FlatRate,
        [Display(Name = "Percentage of Income")] Percentage,
        [Display(Name = "Max Contribution")] Max
    }
}