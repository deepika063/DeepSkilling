using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator.AllClear();
        }

        // ---------- Subtraction ----------

        [TestCase(20, 10, 10)]
        [TestCase(10, 5, 5)]
        [TestCase(5, 10, -5)]
        [TestCase(-5, -5, 0)]
        public void TestSubtraction(double a, double b, double expected)
        {
            double actual = calculator.Subtraction(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ---------- Multiplication ----------

        [TestCase(5, 2, 10)]
        [TestCase(10, 0, 0)]
        [TestCase(-5, 2, -10)]
        [TestCase(-5, -2, 10)]
        public void TestMultiplication(double a, double b, double expected)
        {
            double actual = calculator.Multiplication(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ---------- Division ----------

        [TestCase(20, 2, 10)]
        [TestCase(15, 3, 5)]
        [TestCase(25, 5, 5)]
        public void TestDivision(double a, double b, double expected)
        {
            double actual = calculator.Division(a, b);
            Assert.AreEqual(expected, actual);
        }

        // ---------- Division By Zero ----------

        [Test]
        public void TestDivisionByZero()
        {
            try
            {
                calculator.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Second Parameter Can't be Zero", ex.Message);
            }
        }

        // ---------- Void Method ----------

        [Test]
        public void TestAddAndClear()
        {
            calculator.Addition(10, 20);

            Assert.AreEqual(30, calculator.GetResult);

            calculator.AllClear();

            Assert.AreEqual(0, calculator.GetResult);
        }
    }
}
