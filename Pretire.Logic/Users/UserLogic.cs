using Pretire.Logic.Models;
using System.Collections.Generic;
using Pretire.Logic.Taxes.Calculators;
using Pretire.Logic.Taxes.Calculators.Impl;
using Pretire.Logic.Assets.Models;
using Pretire.Logic.Assets.Calculators.Impl;
using Pretire.Logic.Spending.Models;
using Pretire.Logic.Calculators.Impl;
using Pretire.Data;
using Pretire.Logic.Users.Managers;

namespace Pretire.Logic.Users
{
    public class UserLogic
    {
        public User LoadCurrentUser()
        {
            var briansSalary = new SalaryAsset()
            {
                Name = "Brian's Salary",
                StartingValue = 145000,
                StartingYear = _currentYear,
                EndingYear = 2029,
                GrowthCalculator = new YearEndGrowthCalculator(.05M),
                ContributionCalculator = new NoContributionCalculator(),
                IsActive = true,
                TaxCalculators = new List<ITaxCalculator>()
                {
                    new USASingleTaxCalculator(),
                    new USASocialSecurityCalculator(),
                    new USAMedicareCalculator()
                }
            };
            briansSalary.RetirementCalculator = new Max401kContributionCalculator();
            
            var costs = new List<CostItem>()
            {
                new CostItem()
                {
                    Id = 1,
                    Name = "Mortgage",
                    Type =  "Fixed",
                    Category = "Home",
                    //PaymentType = PaymentType.Monthly,
                    YearlyPaymentAmount = 32400,
                    StartYear = 2011,
                    EndYear = 2041,
                    IsActive = true,
                    RetirementFactor = 1,
                    GrowthCalculator = NoGrowthCostCalculator.Instance
                },
                new CostItem()
                {
                    Id = 2,
                    Name = "Home Insurance",
                    Type =  "Fixed",
                    Category = "Home",
                    //PaymentType = PaymentType.Yearly,
                    YearlyPaymentAmount = 2700,
                    YearlyGrowthRate = .03M,
                    StartYear = _currentYear,
                    EndYear = int.MaxValue,
                    IsActive = true,
                    RetirementFactor = 1,
                    GrowthCalculator = PercentGrowthCostCalculator.Instance
                },
                new CostItem()
                {
                    Id = 3,
                    Name = "Property Tax",
                    Type =  "Fixed",
                    Category = "Home",
                    //PaymentType = PaymentType.Yearly,
                    YearlyPaymentAmount = 6150,
                    YearlyGrowthRate = .03M,
                    StartYear = _currentYear,
                    EndYear = int.MaxValue,
                    IsActive = true,
                    RetirementFactor = 1,
                    GrowthCalculator = PercentGrowthCostCalculator.Instance
                },
                new CostItem()
                {
                    Id = 4,
                    Name = "Electricity",
                    Type =  "Adjustable",
                    Category = "Utilities",
                    //PaymentType = PaymentType.Monthly,
                    YearlyPaymentAmount = 1260,
                    YearlyGrowthRate = .03M,
                    StartYear = _currentYear,
                    EndYear = int.MaxValue,
                    IsActive = true,
                    RetirementFactor = 1,
                    GrowthCalculator = PercentGrowthCostCalculator.Instance
                }
            };

            return new User()
            {
                //Salaries = new List<SalaryAsset>()
                //{
                //    briansSalary
                //},
                //Investments = new List<Asset>()
                //{
                //    new Asset()
                //    {
                //        Id = 1,
                //        Name = "Fidelity + Vanguard",
                //        StartingYear = _currentYear,
                //        EndingYear = 3000,
                //        IsActive = true,
                //        StartingValue = 177803,
                //        TaxCalculators = new List<ITaxCalculator>()
                //        {
                //            new USACapitalGainsCalculator()
                //        },
                //        GrowthCalculator = new EvenDistributionGrowthCalculator(.05M),
                //        ContributionCalculator = new RemainingIncomeContributionCalculator(new List<Asset>() { briansSalary }, costs, 1)
                //    },
                //    new Asset()
                //    {
                //        Id = 2,
                //        Name = "Chase Investmet",
                //        StartingYear = _currentYear,
                //        EndingYear = 3000,
                //        IsActive = true,
                //        StartingValue = 25000,
                //        TaxCalculators = new List<ITaxCalculator>(),
                //        GrowthCalculator = new NoGrowthCalculator(),
                //        ContributionCalculator = new NoContributionCalculator()
                //    }
                //}
                //,
                //Costs = new List<CostItem>()
                //{
                //    new CostItem()
                //    {
                //        Id = 1,
                //        Name = "Mortgage",
                //        Type =  "Fixed",
                //        Category = "Home",
                //        PaymentType = PaymentType.Monthly,
                //        YearlyPaymentAmount = 32400,
                //        StartYear = 2011,
                //        EndYear = 2041,
                //        IsActive = true,
                //        RetirementFactor = 1,
                //        GrowthCalculator = NoGrowthCalculator.Instance
                //    },
                //    new CostItem()
                //    {
                //        Id = 2,
                //        Name = "Home Insurance",
                //        Type =  "Fixed",
                //        Category = "Home",
                //        PaymentType = PaymentType.Yearly,
                //        YearlyPaymentAmount = 2700,
                //        YearlyGrowthRate = .03M,
                //        StartYear = _currentYear,
                //        EndYear = int.MaxValue,
                //        IsActive = true,
                //        RetirementFactor = 1,
                //        GrowthCalculator = PercentGrowthCalculator.Instance
                //    },
                //    new CostItem()
                //    {
                //        Id = 3,
                //        Name = "Property Tax",
                //        Type =  "Fixed",
                //        Category = "Home",
                //        PaymentType = PaymentType.Yearly,
                //        YearlyPaymentAmount = 6150,
                //        YearlyGrowthRate = .03M,
                //        StartYear = _currentYear,
                //        EndYear = int.MaxValue,
                //        IsActive = true,
                //        RetirementFactor = 1,
                //        GrowthCalculator = PercentGrowthCalculator.Instance
                //    },
                //    new CostItem()
                //    {
                //        Id = 4,
                //        Name = "Electricity",
                //        Type =  "Adjustable",
                //        Category = "Utilities",
                //        PaymentType = PaymentType.Monthly,
                //        YearlyPaymentAmount = 1260,
                //        YearlyGrowthRate = .03M,
                //        StartYear = _currentYear,
                //        EndYear = int.MaxValue,
                //        IsActive = true,
                //        RetirementFactor = 1,
                //        GrowthCalculator = PercentGrowthCalculator.Instance
                //    }
                //}
            };
        }
        private int _currentYear = 2018;
    }
}
