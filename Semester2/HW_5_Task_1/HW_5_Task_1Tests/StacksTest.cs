using System;
using System.Collections.Generic;
using HW_5_Task_1;
using NUnit.Framework;

namespace HW_5_Task_1Tests
{
    [Serializable]
    public class StacksTest
    {
        [TestCaseSource(nameof(Stacks))]
        public void PushTest(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestCaseSource(nameof(Stacks))]
        public void PopTest(IStack stack)
        {
            stack.Push(1);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }

        private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new ArrayStack()),
            new TestCaseData(new ListStack()),
        };
    }
}
