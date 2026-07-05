using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new LeapYearCalculator();
        }

        // Leap Year Test Cases
        [TestCase(2000, 1)]
        [TestCase(2024, 1)]
        [TestCase(2016, 1)]
        [TestCase(2400, 1)]
        public void CheckLeapYear_LeapYear_ReturnsOne(int year, int expected)
        {
            int actual = calculator.CheckLeapYear(year);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Non-Leap Year Test Cases
        [TestCase(2023, 0)]
        [TestCase(1900, 0)]
        [TestCase(2019, 0)]
        [TestCase(2100, 0)]
        public void CheckLeapYear_NonLeapYear_ReturnsZero(int year, int expected)
        {
            int actual = calculator.CheckLeapYear(year);

            Assert.That(actual, Is.EqualTo(expected));
        }

        // Invalid Year Test Cases
        [TestCase(1700, -1)]
        [TestCase(10000, -1)]
        [TestCase(0, -1)]
        [TestCase(-100, -1)]
        public void CheckLeapYear_InvalidYear_ReturnsMinusOne(int year, int expected)
        {
            int actual = calculator.CheckLeapYear(year);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
