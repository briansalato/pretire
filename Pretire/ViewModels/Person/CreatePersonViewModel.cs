using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.ViewModels.Person
{
    public class CreatePersonViewModel
    {
        public string Name { get; set; }

        [Display(Name = "Birth year")]
        public int BirthYear { get; set; }
        [Display(Name = "Retirement age")]
        public int RetirementAge { get; set; }

        [Display(Name = "What year is this salary information for?")]
        public int CurrentSalaryYear { get; set; }
        [Display(Name = "Yearly salary")]
        public decimal YearlySalary { get; set; }
        [Display(Name = "Yearly Growth Rate")]
        public decimal YearlySalaryGrowthRate { get; set; }
        [Display(Name = "How will it grow each year?")]
        public GrowthType SalaryGrowthType { get; set; }

        [Display(Name = "What type of 401k do they have?")]
        public AccountType401k TypeOf401k { get; set; }
        [Display(Name = "How much do they conribute to their 401k each year?")]
        public decimal Yearly401kContribution { get; set; }
        [Display(Name = "What type of contribution do they make?")]
        public ContributionTo401kType ContributionTo401kType { get; set; }
        [Display(Name = "How much will their contribution grow each yaer?")]
        public decimal Yearly401kGrowthRate { get; set; }
        [Display(Name = "How will their contribution grow each year?")]
        public GrowthType Yearly401kGrowthRateType { get; set; }
    }
}