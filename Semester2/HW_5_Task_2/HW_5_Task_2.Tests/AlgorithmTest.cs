using NUnit.Framework;

namespace HW_5_Task_2.Tests
{
    [TestFixture]
    class AlgorithmTest
    {
        private int min = int.MinValue;

        [TestCase]
        public void TestPrim()
        {
            int[,] firstGraph =
            {
                { min, 1, 2, 3 },
                { 1, min, 4, 5 },
                { 2, 4, min, 6 },
                { 3, 5, 6, min }
            };
            int[,] firstResult =
            {
                { min, min, min, 3 },
                { min, min, min, 5 },
                { min, min, min, 6 },
                { 3, 5, 6, min }
            };

            Assert.AreEqual(Algorithm.ChangedPrim(firstGraph), firstResult);

            int[,] secondGraph =
            {
                { min, 1, 2, 3 },
                { 1, min, min, min },
                { 2, min, min, min },
                { 3, min, min, min }
            };
            int[,] secondResult =
            {
                { min, 1, 2, 3 },
                { 1, min, min, min },
                { 2, min, min, min },
                { 3, min, min, min }
            };

            Assert.AreEqual(Algorithm.ChangedPrim(secondGraph), secondResult);
        }

        [TestCase]
        public void TestErrorPrim()
        {
            int[,] firstGraph =
            {
                { min, 1, 2, min },
                { 1, min, 4, min },
                { 2, 4, min, min },
                { min, min, min, min }
            };

            Assert.Throws<GraphIsNotConnectedException>(()=>Algorithm.ChangedPrim(firstGraph));

            int[,] secondGraph =
            {
                { min, 1, min, min },
                { 1, min, min, min },
                { min, min, min, 2 },
                { min, min, 2, min }
            };

            Assert.Throws<GraphIsNotConnectedException>(() => Algorithm.ChangedPrim(secondGraph));
        }
    }
}
