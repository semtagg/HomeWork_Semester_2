using NUnit.Framework;
using System;

namespace HW_4_Task_1.Tests
{
    [Serializable]
    public class TreeTest
    {
        private Tree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new();
        }

        [TestCase]
        public void TestBuild()
        {
            tree.Build("( + 1 2 )");
        }

        [TestCase]
        public void ErrorTestBuild()
        {
            Assert.Throws<IncorrectFormOfExpressionException>(() => tree.Build("( @ 1 2 )"));
        }

        [TestCase]
        public void TestCalculate()
        {
            tree.Build("( * ( + 1 ( - 5 3 ) ) ( / 4 2 ) )");
            Assert.AreEqual(6, tree.Calculate());
        }

        [TestCase]
        public void ErrorTestCalculate()
        {
            tree.Build("( / 1 0 )");
            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }
    }
}
