using NUnit.Framework;

namespace HW_4_Task_2.Tests
{
    [TestFixture]
    class UniqueListTest
    {
        private UniqueList uniqueList;

        [SetUp]
        public void SetUp()
        {
            uniqueList = new();

            uniqueList.Insert(10, 0);
            uniqueList.Insert(20, 1);
            uniqueList.Insert(30, 2);
        }

        [TestCase]
        public void TestInsert()
        {
            Assert.Throws<ElementIsAlreadyExistException>(() => uniqueList.Insert(10, 3));
        }

        [TestCase]
        public void TestChange()
        {
            Assert.Throws<ElementIsAlreadyExistException>(() => uniqueList.Change(10, 2));
        }
    }
}
