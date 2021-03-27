using NUnit.Framework;
using System;

namespace HW_3_Task_1.Tests
{
    [Serializable]
    class BTreeTest
    {
        private BTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BTree(2);
            tree.Insert("1", "a");
            tree.Insert("10", "b");
            tree.Insert("20", "c");
            tree.Insert("2", "d");
            tree.Insert("3", "e");
            tree.Insert("4", "f");
            tree.Insert("5", "g");
            tree.Insert("6", "h");
            tree.Insert("7", "i");
            tree.Insert("21", "j");
            tree.Insert("22", "k");
            tree.Insert("23", "l");
            tree.Insert("24", "m");
            tree.Insert("11", "n");
            tree.Insert("12", "o");
            tree.Insert("13", "p");
            tree.Insert("14", "q");
            tree.Insert("15", "r");
            tree.Insert("8", "s");
            tree.Insert("9", "t");
            tree.Insert("16", "u");
            tree.Insert("17", "v");
            tree.Insert("18", "w");
            tree.Insert("19", "x");
        }

        [TestCase]
        public void TestInsert()
        {
            Assert.IsFalse(tree.CheckKey("0"));
            for (int i = 1; i <= 24; i++)
            {
                Assert.IsTrue(tree.CheckKey(i.ToString()));
            }
            Assert.IsFalse(tree.CheckKey("25"));
        }

        [TestCase]
        public void TestGetValue()
        {
            Assert.AreEqual(tree.GetValue("7"), "i");
            Assert.AreEqual(tree.GetValue("13"), "p");
            Assert.AreEqual(tree.GetValue("22"), "k");

            Assert.Throws<ArgumentNullException>(() => tree.GetValue("30"));
        }

        [TestCase]
        public void TestCheckKey()
        {
            Assert.IsTrue(tree.CheckKey("3"));
            Assert.IsTrue(tree.CheckKey("11"));
            Assert.IsTrue(tree.CheckKey("21"));

            Assert.IsFalse(tree.CheckKey("40"));
        }
    }
}
