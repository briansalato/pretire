using Pretire.Builders;
using Pretire.Logic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public class IncomeController : LoggedInController
    {
        // GET: Income
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Salary()
        {
            var viewModel = _incomeBuilder.BuildSalariesViewModel(CurrentUser.People, 2018, 2018 + 40);
            return View(viewModel);
        }

        private IncomeBuilder _incomeBuilder = new IncomeBuilder();
    }
}