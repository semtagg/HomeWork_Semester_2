using NUnit.Framework;
using System;

namespace HW_4_Task_2.Tests
{
    [TestFixture]
    class ListTest
    {
        private List list = new List();

        [TestCase]
        public void TestInsert() // ?
        {
            list.InsertByIndex(10, 0);

            Assert.IsTrue(list != null);
        }

        [TestCase]
        public void TestGetLastValue() // ????????????
        {
            //list.InsertByIndex(20, 0);

            Assert.AreEqual(list.GetLastValue(), 30);
        }

        [TestCase]
        public void TestGetValueByIndex()
        {

            Assert.AreEqual(list.GetValueByIndex(0), 10);
        }

        [TestCase]
        public void TestInsertByIndex()
        {
            list.InsertByIndex(10, 0);
            list.InsertByIndex(20, 1);
            list.InsertByIndex(30, 2);

            Assert.AreEqual(list.GetValueByIndex(1), 20);
        }

        [TestCase]
        public void TestRemoveByIndex()
        {
            list.InsertByIndex(10, 0);
            list.InsertByIndex(20, 1);
            list.InsertByIndex(30, 2);

            list.RemoveByIndex(1);

            Assert.AreEqual(list.GetValueByIndex(1), 30);
        }
        
        [TestCase]
        public void TestRemoveByValue()
        {
            list.InsertByIndex(10, 0);
            list.InsertByIndex(20, 1);
            list.InsertByIndex(30, 2);
            
            //Assert.Throws<DeleteElementException>(() => list.RemoveByValue(40));

            list.RemoveByValue(20);

            Assert.AreEqual(list.GetValueByIndex(1), 30); 
        }

        [TestCase]
        public void TestChangeByIndex()
        {
            list.InsertByIndex(10, 0);
            list.InsertByIndex(20, 1);
            list.InsertByIndex(30, 2);

            list.ChangeByIndex(120, 1);

            Assert.AreEqual(list.GetValueByIndex(1), 120);
            Assert.Throws<IndexOutOfRangeException>(() => list.ChangeByIndex(40, 4));
        }
    }
}

