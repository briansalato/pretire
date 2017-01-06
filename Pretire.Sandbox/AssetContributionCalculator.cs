using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pretire.Sandbox
{
    class AssetContributionCalculator : IContributionCaculator
    {
        public decimal CalculateForYear(int year)
        {
            var contribution = 0M;
            foreach(var contributingAsset in _contributingAssets)
            {
                contribution += contributingAsset.Key.CalculateValue(year).EndingValue * contributingAsset.Value;
            }

            return contribution;
        }

        public AssetContributionCalculator(IDictionary<Asset,decimal> contributingAssets)
        {
            _contributingAssets = contributingAssets;
        }

        private IDictionary<Asset, decimal> _contributingAssets;
    }
}
