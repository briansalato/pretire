using Pretire.Logic.Models;
using Pretire.Logic.Retirement.Impl;
using System.Collections.Generic;
using Pretire.Logic.Calculators.Impl;
using Pretire.Logic.Salary.Models;
using Pretire.Logic.Taxes.Calculators.Impl;
using Pretire.Logic.Spending.Models;
using Pretire.Logic.Assets.Models;

namespace Pretire.Logic.Users
{
    public class UserLogic
    {
        public User LoadCurrentUser()
        {
            return new User()
            {
                People = new List<Person>()
                {
                    new Person()
                    {
                        Name = "Brian",
                        StartingIncome = 145000,
                        IncomeGrowthRate = .05M,
                        StartingYear = _currentYear,
                        IncomeCalculator = PercentGrowthCalculator.Instance,
                        RetirementAccount = new InvestmentAccount401k()
                        {
                            StartingContribution = 18000,
                            GrowthRate = 500,
                            Type = TypeOf401k.Traditional,
                            StartingYear = _currentYear,
                            ContributionCalculator= FlatAmountFlatGrowth401kCalculator.Instance
                        },
                        IncomeTaxCalculator = new SingleFilingIncomeTaxCalculator(),
                        SocialSecurityCalculator = new SocialSecurityCalculator(),
                        MedicareCalculator = new MedicareCalculator()
                    },
                    //new Person()
                    //{
                    //    Name = "Victoria",
                        //StartingIncome = 80000,
                        //IncomeGrowthRate = .03M,
                        //StartingYear = _currentYear,
                    //    IncomeCalculator = new PercenteGrowthIncomeCalculator(),
                    //    RetirementCalculator = new FlatAmountFlatGrowth401kCalculator(18000, 500, _currentYear)
                    //}
                },
                Costs = new List<CostItem>()
                {
                    new CostItem()
                    {
                        Id = 1,
                        Name = "Mortgage",
                        Type =  "Fixed",
                        Category = "Home",
                        PaymentType = PaymentType.Monthly,
                        YearlyPaymentAmount = 32400,
                        StartYear = 2011,
                        EndYear = 2041,
                        IsActive = true,
                        RetirementFactor = 1,
                        GrowthCalculator = NoGrowthCalculator.Instance
                    },
                    new CostItem()
                    {
                        Id = 2,
                        Name = "Home Insurance",
                        Type =  "Fixed",
                        Category = "Home",
                        PaymentType = PaymentType.Yearly,
                        YearlyPaymentAmount = 2700,
                        YearlyGrowthRate = .03M,
                        StartYear = _currentYear,
                        EndYear = int.MaxValue,
                        IsActive = true,
                        RetirementFactor = 1,
                        GrowthCalculator = PercentGrowthCalculator.Instance
                    },
                    new CostItem()
                    {
                        Id = 3,
                        Name = "Property Tax",
                        Type =  "Fixed",
                        Category = "Home",
                        PaymentType = PaymentType.Yearly,
                        YearlyPaymentAmount = 6150,
                        YearlyGrowthRate = .03M,
                        StartYear = _currentYear,
                        EndYear = int.MaxValue,
                        IsActive = true,
                        RetirementFactor = 1,
                        GrowthCalculator = PercentGrowthCalculator.Instance
                    },
                    new CostItem()
                    {
                        Id = 4,
                        Name = "Electricity",
                        Type =  "Adjustable",
                        Category = "Utilities",
                        PaymentType = PaymentType.Monthly,
                        YearlyPaymentAmount = 1260,
                        YearlyGrowthRate = .03M,
                        StartYear = _currentYear,
                        EndYear = int.MaxValue,
                        IsActive = true,
                        RetirementFactor = 1,
                        GrowthCalculator = PercentGrowthCalculator.Instance
                    }
                }
            };
        }
        private int _currentYear = 2018;
    }
}
