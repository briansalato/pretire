using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Pretire.Sandbox.Tests
{
    [TestClass]
    public class SalaryTests
    {
        [TestMethod]
        public void BriansSalary()
        {
            // Test of if I had $100 cash and let it under a mattress
            var asset = new SalaryAsset()
            {
                IsActive = true,
                StartingValue = 145000,
                StartingYear = 2018,
                EndingYear = 2029,
                Name = "Brian's Salary",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new EndOfYearGrowthCalculator(.05M),
                TaxCalculators = new List<ITaxCalculator>()
                {
                    new USASingleTaxCalculator(),
                    new USASocialSecurityCalculator(),
                    new USAMedicareCalculator()
                }
            };

            Assert.AreEqual(0, asset.CalculateValue(2016).EndingValue);
            Assert.AreEqual(145000, asset.CalculateValue(2018).EndingValue);
            Assert.AreEqual(152250, Math.Round(asset.CalculateValue(2019).EndingValue));
            Assert.AreEqual(236190, Math.Round(asset.CalculateValue(2028).EndingValue));
            Assert.AreEqual(247999, Math.Round(asset.CalculateValue(2029).EndingValue));
            Assert.AreEqual(0, asset.CalculateValue(2030).EndingValue);
        }
    }
}
