using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pretire.Logic.Assets.Models;
using Pretire.Logic.Taxes.Calculators.Impl;
using Pretire.Logic.Assets.Calculators.Impl;
using Pretire.Logic.Taxes.Calculators;

namespace Pretire.Sandbox.Tests
{
    [TestClass]
    public class AssetTests
    {
        [TestMethod]
        public void Asset_NotActive()
        {
            // Test of if I had $100 cash and let it under a mattress
            var asset = new Asset()
            {
                IsActive = false,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1910,
                Name = "Sample Raw Cash",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };

            Assert.AreEqual(0, asset.CalculateValue(1899).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1900).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1901).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1909).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1910).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1911).EndingValue);
        }
        [TestMethod]
        public void Asset_NoGrowth_NoContribution()
        {
            // Test of if I had $100 cash and let it under a mattress
            var asset = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1910,
                Name = "Sample Raw Cash",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };

            Assert.AreEqual(0, asset.CalculateValue(1899).EndingValue);
            Assert.AreEqual(100, asset.CalculateValue(1900).EndingValue);
            Assert.AreEqual(100, asset.CalculateValue(1901).EndingValue);
            Assert.AreEqual(100, asset.CalculateValue(1909).EndingValue);
            Assert.AreEqual(100, asset.CalculateValue(1910).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1911).EndingValue);
        }

        [TestMethod]
        public void Asset_WithGrowth_NoContribution()
        {
            // Test of it I had $100 cash and put it in a bank account with interest and never added more
            var asset = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1910,
                Name = "Sample Raw Cash",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new EvenDistributionGrowthCalculator(.05M),
                TaxCalculators = new List<ITaxCalculator>()
            };

            Assert.AreEqual(0M, asset.CalculateValue(1899).EndingValue);
            Assert.AreEqual(105M, asset.CalculateValue(1900).EndingValue);
            Assert.AreEqual(110.25M, asset.CalculateValue(1901).EndingValue);
            Assert.AreEqual(162.89M, Math.Round(asset.CalculateValue(1909).EndingValue, 2));
            Assert.AreEqual(171.03M, Math.Round(asset.CalculateValue(1910).EndingValue, 2));
            Assert.AreEqual(0M, asset.CalculateValue(1911).EndingValue);
        }

        [TestMethod]
        public void Asset_NoGrowth_WithSalaryContribution()
        {
            // Test of it I had $100 cash under a mattress and added 100% of my excess salary to it
            var salary1 = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1905,
                Name = "Salary 1",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };
            var salary2 = new Asset()
            {
                IsActive = true,
                StartingValue = 200,
                StartingYear = 1905,
                EndingYear = 1908,
                Name = "Salary 2",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };
            var salaries = new Dictionary<Asset, decimal>()
            {
                { salary1, .5M },
                { salary2, .75M }
            };
            var asset = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1910,
                Name = "Sample Raw Cash",
                ContributionCalculator = new AssetContributionCalculator(salaries),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };

            Assert.AreEqual(0, asset.CalculateValue(1899).EndingValue);
            Assert.AreEqual(150, asset.CalculateValue(1900).EndingValue);
            Assert.AreEqual(200, asset.CalculateValue(1901).EndingValue);
            Assert.AreEqual(250, asset.CalculateValue(1902).EndingValue);
            Assert.AreEqual(300, asset.CalculateValue(1903).EndingValue);
            Assert.AreEqual(350, asset.CalculateValue(1904).EndingValue);
            Assert.AreEqual(550, asset.CalculateValue(1905).EndingValue);
            Assert.AreEqual(700, asset.CalculateValue(1906).EndingValue);
            Assert.AreEqual(850, asset.CalculateValue(1907).EndingValue);
            Assert.AreEqual(1000, asset.CalculateValue(1908).EndingValue);
            Assert.AreEqual(1000, asset.CalculateValue(1909).EndingValue);
            Assert.AreEqual(1000, asset.CalculateValue(1910).EndingValue);
            Assert.AreEqual(0, asset.CalculateValue(1911).EndingValue);
        }

        [TestMethod]
        public void Asset_WithGrowth_WithSalaryContribution()
        {
            // Test of it I had $100 cash under a mattress and added 100% of my excess salary to it
            var salary1 = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1905,
                Name = "Salary 1",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };
            var salary2 = new Asset()
            {
                IsActive = true,
                StartingValue = 200,
                StartingYear = 1905,
                EndingYear = 1908,
                Name = "Salary 2",
                ContributionCalculator = new NoContributionCalculator(),
                GrowthCalculator = new NoGrowthCalculator(),
                TaxCalculators = new List<ITaxCalculator>()
            };
            var salaries = new Dictionary<Asset, decimal>()
            {
                { salary1, .5M },
                { salary2, .75M }
            };
            var asset = new Asset()
            {
                IsActive = true,
                StartingValue = 100,
                StartingYear = 1900,
                EndingYear = 1910,
                Name = "Sample Raw Cash",
                ContributionCalculator = new AssetContributionCalculator(salaries),
                GrowthCalculator = new EvenDistributionGrowthCalculator(.05M),
                TaxCalculators = new List<ITaxCalculator>()
            };

            Assert.AreEqual(0M, asset.CalculateValue(1899).EndingValue);
            Assert.AreEqual(156.25M, Math.Round(asset.CalculateValue(1900).EndingValue, 2));
            Assert.AreEqual(215.31M, Math.Round(asset.CalculateValue(1901).EndingValue, 2));
            Assert.AreEqual(277.33M, Math.Round(asset.CalculateValue(1902).EndingValue, 2));
            Assert.AreEqual(342.44M, Math.Round(asset.CalculateValue(1903).EndingValue, 2));
            Assert.AreEqual(410.82M, Math.Round(asset.CalculateValue(1904).EndingValue, 2));
            Assert.AreEqual(636.36M, Math.Round(asset.CalculateValue(1905).EndingValue, 2));
            Assert.AreEqual(821.93M, Math.Round(asset.CalculateValue(1906).EndingValue, 2));
            Assert.AreEqual(1016.77M, Math.Round(asset.CalculateValue(1907).EndingValue, 2));
            Assert.AreEqual(1221.36M, Math.Round(asset.CalculateValue(1908).EndingValue, 2));
            Assert.AreEqual(1282.43M, Math.Round(asset.CalculateValue(1909).EndingValue, 2));
            Assert.AreEqual(1346.55M, Math.Round(asset.CalculateValue(1910).EndingValue, 2));
            Assert.AreEqual(0, asset.CalculateValue(1911).EndingValue);
        }
    }
}
