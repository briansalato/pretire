using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Logic.Assets.Models
{
    public enum GrowthType
    {
        [Display(Name = "No Growth")]
        None = 0,
        [Display(Name = "Grow by Flat Amount")]
        FlatAmount,
        [Display(Name = "Percentage of Previous Year")]
        Percentage
    }
}
