using System;
using NUnit.Framework;

namespace HW_6_Task_2.Tests
{
    [Serializable]
    public class GameTest
    {
        private Map map;

        [SetUp]
        public void SetUp()
        {
            map = new Map("../../test_map_1.txt");
        }

        [Test]
        public void MoveOnDownTest()
        {
            (int X, int Y) old = map.GetCoordinates();
            map.TryMove((old.X, old.Y + 1));
            Assert.AreEqual(old, map.GetCoordinates());
        }

        [Test]
        public void MoveOnUpTest()
        {
            (int X, int Y) old = map.GetCoordinates();
            map.TryMove((old.X, old.Y - 1));
            Assert.AreEqual(old, map.GetCoordinates());
        }

        [Test]
        public void MoveOnRightTest()
        {
            (int X, int Y) old = map.GetCoordinates();
            map.TryMove((old.X + 1, old.Y));
            Assert.AreEqual(old, map.GetCoordinates());
        }

        [Test]
        public void MoveOnLeftTest()
        {
            (int X, int Y) old = map.GetCoordinates();
            map.TryMove((old.X - 1, old.Y));
            Assert.AreEqual(old, map.GetCoordinates());
        }

        [Test]
        public void MoveOnWallTest()
        {
            (int X, int Y) old = map.GetCoordinates();
            map.TryMove((old.X - 1, old.Y));
            Assert.AreEqual(old, map.GetCoordinates());
        }
    }
}
