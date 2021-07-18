using System;
using System.Collections.Generic;
using HW_5_Task_1;
using NUnit.Framework;

namespace HW_5_Task_1Tests
{
    [Serializable]
    public class CalculatorsTest
    {
        [TestCaseSource(nameof(Calculators))]
        public void TestCalculators(Calculator calculator)
        {
            Assert.AreEqual(3d, calculator.GetResult("1 2 +"), 10e-6);
            Assert.AreEqual(29d, calculator.GetResult("3 5 + 2 * 6 7 + 8 9 - / -"), 10e-6);
            Assert.AreEqual(3.4d, calculator.GetResult("6 10 + 4 - 1 2 2 * + / 1 +"), 10e-6);
        }

        [TestCaseSource(nameof(Calculators))]
        public void ErrorTestCalculators(Calculator calculator)
        {
            Assert.Throws<InvalidOperationException>(() => calculator.GetResult("avdsa"));
            Assert.Throws<InvalidOperationException>(() => calculator.GetResult("3 + 5"));
            Assert.Throws<DivideByZeroException>(() => calculator.GetResult("2 0 /"));
        }

        private static IEnumerable<TestCaseData> Calculators
        => new TestCaseData[]
        {
            new TestCaseData(new Calculator(new ArrayStack())),
            new TestCaseData(new Calculator(new ListStack())),
        };
    }
}
