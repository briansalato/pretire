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
        public ActionResult Index()
        {
            var viewModel = _spendingBuilder.BuildSpendingSummaryViewModel(CurrentUser.Costs, 2018, 2018 + 40);
            return View(viewModel);
        }

        private SpendingBuilder _spendingBuilder = new SpendingBuilder();
    }
}