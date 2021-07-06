using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HW_6_Task_1.Tests
{
    [Serializable]
    class MethodsTest
    {
        [TestCase]
        public void MapTest()
        {
            var firstList = Methods.Map(new List<int>() { 1, 2, 3 }, x => x + 2);
            Assert.AreEqual(firstList, new List<int>() { 3, 4, 5 });

            var secondList = Methods.Map(new List<int>() { 1, 2, 3 }, x => x.ToString());
            Assert.AreEqual(secondList, new List<string>() { "1", "2", "3" });
        }

        [TestCase]
        public void FilterTest()
        {
            var firstList = Methods.Filter(new List<int>() { 1, 2, 3 }, x => x > 1);
            Assert.AreEqual(firstList, new List<int>() { 2, 3 });

            var secondList = Methods.Filter(new List<string>() { "a", "ab", "abc" }, x => x.Length > 1);
            Assert.AreEqual(secondList, new List<string>() { "ab", "abc" });
        }

        [TestCase]
        public void FoldTest()
        {
            var firstValue = Methods.Fold(new List<int>() { 1, 2, 3 }, 1, (x, y) => x * y);
            Assert.AreEqual(firstValue, 6);

            var secondValue = Methods.Fold(new List<string>() { "a", "ab", "abc" }, "", (x, y) => x + y);
            Assert.AreEqual(secondValue, "aababc");
        }
    }
}
