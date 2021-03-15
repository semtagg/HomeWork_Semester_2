using System;
using HW_5_Task_1;
using NUnit.Framework;

namespace HW_5_Task_1Tests
{
    [Serializable]
    public class CalculatorsTest
    {
        private IStack[] calculators = {new ArrayStack(), new ListStack()};

        [TestCase]
        public void TestCalculators()
        {
            for (int i = 0; i < calculators.Length; i++)
            {
                var calcElement = new Calculator(calculators[i]);

                Assert.AreEqual(calcElement.GetResult("1 2 +"), 3d);
                Assert.AreEqual(calcElement.GetResult("3 5 + 2 * 6 7 + 8 9 - / -"), 29d);
                Assert.AreEqual(calcElement.GetResult("6 10 + 4 - 1 2 2 * + / 1 +"), 3.4d);
            }
        }

        [TestCase]
        public void ErrorTestCalculators()
        {
            for (int i = 0; i < calculators.Length; i++)
            {
                var calcElement = new Calculator(calculators[i]);

                Assert.Throws<InvalidOperationException>(() => calcElement.GetResult("avdsa"));
                Assert.Throws<InvalidOperationException>(() => calcElement.GetResult("3 + 5"));
                Assert.Throws<DivideByZeroException>(() => calcElement.GetResult("2 0 /"));
            }
        }
    }
}
