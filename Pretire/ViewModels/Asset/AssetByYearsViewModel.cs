using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Asset
{
    public class AssetByYearsViewModel
    {
        public string Name { get; set; }
        public ICollection<YearlySummary> YearlyData { get; set; }
    }
}