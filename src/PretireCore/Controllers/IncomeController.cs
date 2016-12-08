using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pretire.Logic;
using Pretire.Models;

namespace Pretire.Controllers
{
    public class IncomeController : LoggedInController
    {
        public IActionResult Index()
        {
            //var yearlyValues = _incomeLogic.GetYearlySalaries(base.CurrentProfile.Family.People, base.CurrentProfile.Settings.StartingYear, base.CurrentProfile.Settings.EndingYear);

            return View();
        }

        public IncomeController(IIncomeLogic incomeLogic)
        {
            _incomeLogic = incomeLogic;
        }

        private IIncomeLogic _incomeLogic;
    }
}