using System;
using NUnit.Framework;

namespace HW_6_Task_2.Tests
{
    [Serializable]
    public class MapTest
    {
        [Test]
        public void MapInitTest()
        {
            bool[,] newMap =
            {
                { false, false, false, false },
                { false, true, true, false },
                { false, false, false, false },
            };
            Assert.AreEqual(newMap, new Map("test_map_3.txt").GetMap());
        }

        [Test]
        public void MapErrorInitTest()
        {
            Assert.Throws<PlayerNotFoundException>(() => new Map("test_map_2.txt"));
        }

        [Test]
        public void GetPositionOfPlayerOnMapTest()
        {
            Assert.AreEqual((1,1), new Map("test_map_3.txt").GetCoordinates());
        }

        [Test]
        public void GetSizeOfMapTest()
        {
            Assert.AreEqual((4, 3), new Map("test_map_3.txt").GetMax());
        }
    }
}
