using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pretire.Logic.Retirement;
using Pretire.Logic.Retirement.Impl;

namespace Pretire.Logic.Tests.Retirement
{
    [TestClass]
    public class FlatAmountFlatGrowth401kCalculatorTests
    {
        [TestInitialize]
        public void Setup()
        {
            _retirementCalculator = FlatAmountFlatGrowth401kCalculator.Instance;
        }

        [TestMethod]
        public void CalculateContribution_OnStartingYear()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 1000, 100, 0);

            // Assert
            Assert.AreEqual(1000, result, "The first year's contribution should be the provided value");
        }

        [TestMethod]
        public void CalculateContribution_AfterSeveralYears()
        {
            // Arrange

            // Act 
            var result = _retirementCalculator.CalculateContribution(100000, 1000, 100, 2);

            // Assert
            Assert.AreEqual(1200, result, "The contribution should grow by the growth amount each year after the first");
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
            var result = _retirementCalculator.CalculateContribution(100000, 0, 100, 2);

            // Assert
            Assert.AreEqual(200, result, "The contribution should only grow based on the growth factor");
        }

        [TestMethod]
        public void CalculateContribution_ShouldNotExceedYearlyIncome()
        {
            // Arrange

            // Act
            var result = _retirementCalculator.CalculateContribution(1000, 100000, 100, 2);

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
