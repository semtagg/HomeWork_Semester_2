using NUnit.Framework;

namespace HW_4_Task_2.Tests
{
    [TestFixture]
    class UniqueListTest
    {
        private UniqueList uniqueList = new UniqueList();

        [TestCase]
        public void TestInsertByIndex()
        {
            uniqueList.InsertByIndex(10, 0);
            Assert.Throws<AddElementException>(() => uniqueList.InsertByIndex(10, 0));
        }
    }
}
