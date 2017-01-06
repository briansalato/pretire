using Pretire.Builders;
using Pretire.ViewModels.Salary;
using System.Web.Mvc;
using Pretire.Logic.Converters;
using System.Linq;
using Pretire.Logic.Assets.Managers;
using Pretire.Logic.Assets.Models;
using System.Collections.Generic;
using Pretire.Logic.Taxes.Calculators;

namespace Pretire.Controllers
{
    public class SalaryController : LoggedInController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var salaries = _salaryManager.GetForSimulation(CurrentSimulationId);
            var viewModel = _salaryBuilder.BuildSalarySummaryViewModel(salaries);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new CreateSalaryViewModel());
        }

        [HttpPost]
        public ActionResult New(CreateSalaryViewModel salaryViewModel)
        {
            var salaryToCreate = new SalaryAsset()
            {
                Name = salaryViewModel.Name,
                IsActive = true,
                StartingValue = salaryViewModel.YearlySalary,
                StartingYear = salaryViewModel.CurrentSalaryYear,
                EndingYear = salaryViewModel.BirthYear + salaryViewModel.RetirementAge,
                GrowthCalculator = salaryViewModel.SalaryGrowthType.ToDomainModel(salaryViewModel.YearlySalaryGrowthRate),
                TaxCalculators = new List<ITaxCalculator>()
            };

            salaryViewModel;

            return null;
        }

        [HttpGet]
        public ActionResult ByYear(int startYear = 2018, int endYear = 2058)
        {
            var salaries = _salaryManager.GetForSimulation(CurrentSimulationId);
            var viewModel = _salaryBuilder.BuildSalariesViewModel(salaries, startYear, endYear);
            return View(viewModel);
        }

        private SalaryBuilder _salaryBuilder = new SalaryBuilder();
        private SalaryManager _salaryManager = new SalaryManager();
        private TaxCodeManager _taxCodeManager = new TaxCodeManager();
    }
}