using NUnit.Framework;
using System;

namespace Test_2.Tests
{
    [TestFixture]
    class PriorityQueueTest
    {
        private PriorityQueue<string> queue;

        [SetUp]
        public void SetUp()
        {
            queue = new PriorityQueue<string>();
            queue.Enqueue("a", 40);
            queue.Enqueue("b", 40);
            queue.Enqueue("c", 40);
            queue.Enqueue("d", 80);
            queue.Enqueue("e", 20);
        }

        [TestCase]
        public void EnqueueTest()
        {
            Assert.IsFalse(queue.IsEmpty());
        }

        [TestCase]
        public void DequeueTest()
        {
            var result = queue.Dequeue();
            Assert.AreEqual(result, "d");
            result = queue.Dequeue();
            Assert.AreEqual(result, "a");
            result = queue.Dequeue();
            Assert.AreEqual(result, "b");
            result = queue.Dequeue();
            Assert.AreEqual(result, "c");
            result = queue.Dequeue();
            Assert.AreEqual(result, "e");
            Assert.Throws<NullReferenceException>(() => queue.Dequeue());
        }
    }
}
