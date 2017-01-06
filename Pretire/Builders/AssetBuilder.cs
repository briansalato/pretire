using Pretire.Logic.Assets.Models;
using Pretire.ViewModels;
using Pretire.ViewModels.Asset;
using System.Collections.Generic;
using System.Linq;

namespace Pretire.Builders
{
    public class AssetBuilder
    {
        public AssetByYearsViewModel BuildAssetByYears(Asset asset, int startYear, int endYear)
        {
            var viewModel = new AssetByYearsViewModel();
            viewModel.Name = asset.Name;
            viewModel.YearlyData = new List<YearlySummary>();

            for(int year = startYear; year <= endYear; year++)
            {
                viewModel.YearlyData.Add(asset.CalculateValue(year));
            }

            return viewModel;
        }
    }
}