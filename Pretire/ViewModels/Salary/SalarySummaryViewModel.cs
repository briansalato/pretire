using Pretire.Logic.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pretire.ViewModels.Salary
{
    public class SalarySummaryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal StartingSalary { get; set; }
        public decimal GrowthRate { get; set; }
        public string GrowthTypeDescription { get; set; }

        public SalarySummaryViewModel(SalaryAsset salary)
        {
            Id = salary.Id;
            Name = salary.Name;
            StartingSalary = salary.StartingValue;
            GrowthRate = salary.GrowthCalculator.YearlyGrowthRate;
            GrowthTypeDescription = salary.GrowthCalculator.Description;
        }
    }
}