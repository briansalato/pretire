using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Person
{
    public enum GrowthType
    {
        [Display(Name = "No Growth")] None,
        [Display(Name = "Grow by Flat Amount")] FlatAmount,
        [Display(Name = "Percentage of Previous Year")] Percentage
    }
}