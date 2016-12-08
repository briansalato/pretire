using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pretire.Logic.Taxes.Models;
using Pretire.Logic.Taxes.Calculators;
using Pretire.Logic.Taxes.Calculators.Impl;

namespace Pretire.Logic.Tests.Taxes
{
    [TestClass]
    public class SingleFilingIncomeTaxCalculatorTests
    {
        [TestInitialize]
        public void Setup()
        {
            var taxBrackets = new List<TaxBracket>()
            {
                new TaxBracket()
                {
                    LowerBound = 0,
                    UpperBound = 100,
                    TaxRate = .1M
                },
                new TaxBracket()
                {
                    LowerBound = 100,
                    UpperBound = 300,
                    TaxRate = .2M
                },
                new TaxBracket()
                {
                    LowerBound = 300,
                    UpperBound = 10000,
                    TaxRate = .3M
                }
            };
            _taxCalculator = new SingleFilingIncomeTaxCalculator(taxBrackets);
        }

        [TestMethod]
        public void CalculateIncomeTax_DoesNotAddBracketsAboveIncome()
        {
            // Arrange
            var salary = 90;
            var contribution = 0;
            var deductions = 0;

            // Act
            var result = _taxCalculator.CalculateTax(salary, contribution, deductions);

            // Assert
            Assert.AreEqual(9, result, "Only the bottom bracket should have been used");
        }

        [TestMethod]
        public void CalculateIncomeTax_UsesUpperBoundForLowerBracketsAndIncomeNotUpperBoundForCurrentBracket()
        {
            // Arrange
            var salary = 600;
            var contribution = 0;
            var deductions = 0;

            // Act
            var result = _taxCalculator.CalculateTax(salary, contribution, deductions);

            // Assert
            Assert.AreEqual(140, result, "The lower brackets should have been fulled used and 300 left over at the last tax rate"); // 100 * .1 + 200 * .2 + 300 * .3
        }

        [TestMethod]
        public void CalculateIncomeTax_Removes401kFromCalculation()
        {
            // Arrange
            var salary = 100;
            var contribution = 50;
            var deductions = 0;

            // Act
            var result = _taxCalculator.CalculateTax(salary, contribution, deductions);

            // Assert
            Assert.AreEqual(5, result, "The 401k contribution was not removed from the income before calculating tax");
        }

        [TestMethod]
        public void CalculateIncomeTax_RemovesDeductionsFromCalculation()
        {
            // Arrange
            var salary = 100;
            var contribution = 0;
            var deductions = 30;

            // Act
            var result = _taxCalculator.CalculateTax(salary, contribution, deductions);

            // Assert
            Assert.AreEqual(7, result, "The deductions were not removed from the income before calculating tax");
        }

        private IIncomeTaxCalculator _taxCalculator;
    }
}
