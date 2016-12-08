using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pretire.Logic.Retirement.Impl;
using Pretire.Logic.Retirement;

namespace Pretire.Logic.Tests.Retirement
{
    [TestClass]
    public class FlatAmountPercentageGrowth401kCalculatorTests
    {
        [TestInitialize]
        public void Setup()
        {
            _retirementCalculator = FlatAmountPercentageGrowth401kCalculator.Instance;
        }

        [TestMethod]
        public void CalculateContribution_OnStartingYear()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 1000, .05M, 0);

            // Assert
            Assert.AreEqual(1000, result, "The first year's contribution should be the provided value");
        }

        [TestMethod]
        public void CalculateContribution_AfterSeveralYears()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 1000, .05M, 2);

            // Assert
            Assert.AreEqual(1102.5M, result, "The contribution should grow by the growth rate each year after the first");
        }

        [TestMethod]
        public void CalculateContribution_WithNoGrowth()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 1000, 0, 2);

            // Assert
            Assert.AreEqual(1000, result, "The contribution should be the same as the provided value");
        }

        [TestMethod]
        public void CalculateContribution_WithNoStartingValue()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 0, .5M, 2);

            // Assert
            Assert.AreEqual(0, result, "Since there is no starting value then the growth will also be zero");
        }

        [TestMethod]
        public void CalculateContribution_ShouldNotExceedYearlyIncome()
        {
            // Arrange

            // Act
            var result = _retirementCalculator.CalculateContribution(100000, 10000000, .05M, 2);

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
