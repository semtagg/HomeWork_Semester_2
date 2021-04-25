using NUnit.Framework;
using System;

namespace HW_8_Task_1.Tests
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
            Assert.IsNull(tree.Search("0"));
            for (int i = 1; i <= 24; i++)
            {
                Assert.IsNotNull(tree.Search(i.ToString()));
            }
            Assert.IsNull(tree.Search("25"));
        }

        [TestCase]
        public void TestSearch()
        {
            Assert.AreEqual(tree.Search("7").Pointer, "i");
            Assert.AreEqual(tree.Search("13").Pointer, "p");
            Assert.AreEqual(tree.Search("22").Pointer, "k");

            Assert.IsNull(tree.Search("30"));
        }

        [TestCase]
        public void TestIsContained()
        {
            Assert.IsTrue(tree.IsContained("3"));
            Assert.IsTrue(tree.IsContained("11"));
            Assert.IsTrue(tree.IsContained("21"));

            Assert.IsFalse(tree.IsContained("40"));
        }

        [TestCase]
        public void TestChange()
        {
            tree.Change("1", "aa");
            Assert.AreEqual(tree.Search("1").Pointer, "aa");
            tree.Change("16", "uu");
            Assert.AreEqual(tree.Search("16").Pointer, "uu");
            tree.Change("24", "mm");
            Assert.AreEqual(tree.Search("24").Pointer, "mm");

            Assert.Throws<ArgumentNullException>(() => tree.Change("25", "xx"));
        }

        [TestCase]
        public void TestDelete()
        {
            tree.Delete("1");
            Assert.IsFalse(tree.IsContained("1"));
            tree.Delete("2");
            Assert.IsFalse(tree.IsContained("2"));
            tree.Delete("3");
            Assert.IsFalse(tree.IsContained("3"));

            Assert.Throws<ArgumentNullException>(() => tree.Delete("25"));
        }
    }
}