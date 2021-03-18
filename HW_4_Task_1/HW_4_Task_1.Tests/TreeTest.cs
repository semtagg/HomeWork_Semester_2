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
            tree = new Tree();
        }

        [TestCase]
        public void TestBuild()
        {
            tree.Build("( + 1 2 )".Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        [TestCase]
        public void ErrorTestBuild()
        {
            Assert.Throws<CorrectExpressionException>(() => tree.Build("( @ 1 2 )".Split(' ', StringSplitOptions.RemoveEmptyEntries)));
        }

        [TestCase]
        public void TestCalculate()
        {
            tree.Build("( * ( + 1 ( - 5 3 ) ) ( / 4 2 ) )".Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.AreEqual(6, tree.Calculate());
        }

        [TestCase]
        public void ErrorTestCalculate()
        {
            tree.Build("( / 1 0 )".Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Assert.Throws<DivideByZeroException>(() => tree.Calculate());
        }
    }
}
