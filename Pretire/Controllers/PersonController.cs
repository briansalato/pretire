using Pretire.Builders;
using Pretire.ViewModels.Person;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public class PersonController : LoggedInController
    {
        // GET: Income
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new CreatePersonViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreatePersonViewModel person)
        {
            return null;
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