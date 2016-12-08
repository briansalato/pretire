using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pretire.Logic.Retirement.Impl;
using Pretire.Logic.Retirement;

namespace Pretire.Logic.Tests.Retirement
{
    [TestClass]
    public class PercentageRatePercentageGrowth401kCalculatorTests
    {
        [TestInitialize]
        public void Setup()
        {
            _retirementCalculator = PercentageRatePercentageGrowth401kCalculator.Instance;
        }

        [TestMethod]
        public void CalculateContribution_OnStartingYear()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, .05M, .02M, 0);

            // Assert
            Assert.AreEqual(5000, result, "The first year's contribution should be the income times the starting rate");
        }

        [TestMethod]
        public void CalculateContribution_AfterSeveralYears()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, .05M, .02M, 2);

            // Assert
            Assert.AreEqual(5202, result, "The contribution rate should increase by multiplying the growth rate to the starting rate. It should not add it to it");
        }

        [TestMethod]
        public void CalculateContribution_WithNoGrowth()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, .05M, 0, 2);

            // Assert
            Assert.AreEqual(5000, result, "The contribution rate should not increase");
        }

        [TestMethod]
        public void CalculateContribution_WithNoStartingValue()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 0, 100, 2);

            // Assert
            Assert.AreEqual(0, result, "Since there is no starting value then the growth will also be zero");
        }

        [TestMethod]
        public void CalculateContribution_ShouldNotExceedYearlyIncome()
        {
            // Arrange

            // Act
            var result = _retirementCalculator.CalculateContribution(1000, 1.1M, 1, 2);

            // Assert
            Assert.AreEqual(1000, result, "The contribution amount should not exceed the yearly income");
        }

        [TestMethod]
        public void CalculateContribution_ShouldNotExceedTheMaximumLimit()
        {
            Assert.Fail();
        }

        private IRetirementCalculator _retirementCalculator;
    }
}
