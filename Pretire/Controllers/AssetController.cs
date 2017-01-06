using Pretire.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public class AssetController : LoggedInController
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssetByYears(int assetId)
        {
            //var asset = CurrentUser.Investments.FirstOrDefault(investment => investment.Id == assetId);
            var viewModel = 1;// _assetBuilder.BuildAssetByYears(asset, 2018, 2018+40);
            return View(viewModel);
        }

        private AssetBuilder _assetBuilder = new AssetBuilder();
    }
}