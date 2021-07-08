using NUnit.Framework;
using System;

namespace HW_7_Task_1.Tests
{
    public class CalculatorTest
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void CalculationsTest()
        {
            calc.TryCalculate("-");
            calc.TryCalculate("1");
            calc.TryCalculate("+");
            calc.TryCalculate("1");
            Assert.AreEqual("0+", calc.TryCalculate("+"));
            calc.TryCalculate("2");
            calc.TryCalculate("*");
            calc.TryCalculate("2");
            Assert.AreEqual("4/", calc.TryCalculate("/"));
            calc.TryCalculate("4");
            Assert.AreEqual("1", calc.TryCalculate("="));
        }

        [Test]
        public void DivisionByZeroTest()
        {
            calc.TryCalculate("1");
            calc.TryCalculate("/");
            calc.TryCalculate("0");
            Assert.Throws<DivideByZeroException>(() => calc.TryCalculate("="));
        }
    }
}