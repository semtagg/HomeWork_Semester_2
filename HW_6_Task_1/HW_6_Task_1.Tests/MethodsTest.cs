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
            Assert.AreEqual(Methods.Map(new List<int>() { 1, 2, 3 }, x => x + 2), new List<int>() { 3, 4, 5 });
            Assert.AreEqual(Methods.Map(new List<int>() { 1, 2, 3 }, x => x.ToString()), new List<string>() { "1", "2", "3" });
        }

        [TestCase]
        public void FilterTest()
        {
            Assert.AreEqual(Methods.Filter(new List<int>() { 1, 2, 3 }, x => x > 1), new List<int>() { 2, 3 });
            Assert.AreEqual(Methods.Filter(new List<string>() { "a", "ab", "abc" }, x => x.Length > 1), new List<string>() { "ab", "abc" });
        }

        [TestCase]
        public void FoldTest()
        {
            Assert.AreEqual(Methods.Fold(new List<int>() { 1, 2, 3 }, 1, (x, y) => x * y), 6);
            Assert.AreEqual(Methods.Fold(new List<string>() { "a", "ab", "abc" }, "", (x, y) => x + y), "aababc");
        }
    }
}
