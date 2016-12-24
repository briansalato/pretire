using Pretire.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public class SpendingController : LoggedInController
    {
        // GET: Spending
        public ActionResult Summary()
        {
            var viewModel = _spendingBuilder.BuildSpendingByYearViewModel(CurrentUser.Costs, 2018, 2018 + 40);
            return View(viewModel);
        }

        public ActionResult Index()
        {
           // var viewModel = _spendingBuilder.BuildCostListViewModel(CurrentUser.Costs);
            return View(CurrentUser.Costs);
        }

        private SpendingBuilder _spendingBuilder = new SpendingBuilder();
    }
}