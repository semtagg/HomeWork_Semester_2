using NUnit.Framework;

namespace HW_2_Task_1
{
    [TestFixture]
    class TestTrie
    {
        private Trie trie = new Trie();

        [TestCase]
        public void Init()
        {
            Assert.IsNotNull(trie);
        }

        [TestCase]
        public void TryAdd()
        {
            Assert.AreEqual(0, trie.LastResult);
            Assert.AreEqual(-1, trie.TryAdd(48));
            Assert.AreEqual(48, trie.LastResult);
            Assert.AreEqual(48, trie.TryAdd(70));

            Assert.AreEqual(-1, trie.TryAdd(48));
            Assert.AreEqual(48, trie.LastResult);
            Assert.AreEqual(-1, trie.TryAdd(70));
            Assert.AreEqual(256, trie.LastResult);
            Assert.AreEqual(256, trie.TryAdd(80));
        }

        [TestCase]
        public void GetLastResult()
        {
            Assert.AreEqual(0, trie.GetLastResult());
            trie.TryAdd(30);
            Assert.AreEqual(30, trie.GetLastResult());
            trie.TryAdd(40);
            Assert.AreEqual(30, trie.GetLastResult());

            trie.TryAdd(30);
            trie.TryAdd(40);
            trie.TryAdd(50);
            Assert.AreEqual(256, trie.GetLastResult());
        }
    }
}
