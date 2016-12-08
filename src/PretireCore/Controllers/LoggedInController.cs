using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pretire.Models;
using Pretire.Models.Taxes;

namespace Pretire.Controllers
{
    public abstract class LoggedInController : Controller
    {
        private Profile _currentProfile;
        protected Profile CurrentProfile
        {
            get
            {
                if (_currentProfile == null)
                {
                    _currentProfile = new Profile()
                    {
                        Family = new Family()
                        {
                            TaxFileType = TaxFilingType.MarriedFillingTogether,
                            People = new List<Person>()
                            {
                                new Person()
                                {
                                    Name = "Brian",
                                    Salary = 145000,
                                    SalaryGrowthRate = .05M,
                                    RetirementAge = 40,
                                    MaxOut401k = true,
                                    UsePercentage401kContribution = false
                                },
                                new Person()
                                {
                                    Name = "Victoria",
                                    Salary = 80000,
                                    SalaryGrowthRate = .03M,
                                    RetirementAge = 40,
                                    MaxOut401k = true,
                                    UsePercentage401kContribution = false
                                }
                            }
                        },
                        Settings = new ProfileSettings()
                    };
                }
                return _currentProfile;
            }
        }
    }
}