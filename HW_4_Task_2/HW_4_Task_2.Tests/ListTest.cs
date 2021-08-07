using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HW_4_Task_2.Tests
{
    [TestFixture]
    class ListTest
    {
        [TestCaseSource(nameof(Lists))]
        public void TestInsert(List list)
        {
            list.Insert(10, 0);

            Assert.IsNotEmpty(Lists());

            list.Insert(20, 1);
            list.Insert(30, 2);

            Assert.AreEqual(1, list.SearchByValue(20));
        }

        [TestCaseSource(nameof(Lists))]
        public void TestRemove(List list)
        {
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.Insert(30, 2);

            list.Remove(1);

            Assert.AreEqual(1, list.SearchByValue(30));
        }

        [TestCaseSource(nameof(Lists))]
        public void TestChange(List list)
        {
            list.Insert(10, 0);
            list.Insert(20, 1);
            list.Insert(30, 2);

            list.Change(120, 1);

            Assert.AreEqual(1, list.SearchByValue(120));
            Assert.AreEqual(-1, list.SearchByValue(20)); 
            Assert.Throws<IndexOutOfRangeException>(() => list.Change(40, 4));
        }

        private static IEnumerable<TestCaseData> Lists()
            => new TestCaseData[]
            {
                new TestCaseData(new List()),
                new TestCaseData(new UniqueList()),
            };
    }
}
