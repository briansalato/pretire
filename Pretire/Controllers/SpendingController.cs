using Pretire.Builders;
using Pretire.Logic.Spending.Models;
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

        public ActionResult Index(int? costId)
        {
            //var viewModel = _spendingBuilder.BuildCostListViewModel(CurrentUser.Costs);
            return View(CurrentUser.Costs);
        }

        public ActionResult CostByYear(int costId)
        {
            var viewModel = _spendingBuilder.BuildCostByYearViewModel(CurrentUser.Costs.FirstOrDefault(cost => cost.Id == costId), 2019, 2018+40);
            return View(viewModel);
        }

        private SpendingBuilder _spendingBuilder = new SpendingBuilder();
    }
}