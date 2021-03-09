using System.Collections.Generic;

namespace HW_2_Task_1
{
    /// <summary>
    /// A data structure called the Prefix tree.
    /// </summary>
    public class Trie
    { 
        class Node
        {
            public byte Symbol { get; set; }

            public int Index { get; set; }

            public int Data { get; set; }

            public Dictionary<byte, Node> Subnodes { get; set; }

            public Node(byte symbol, int index)
            {
                Symbol = symbol;
                Index = index;
                Subnodes = new Dictionary<byte, Node>();
            }

            public Node TryFind(byte symbol)
            {
                if (Subnodes.TryGetValue(symbol, out Node value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
        }

        public int LastResult { get; set; }

        public int Count { get; set; }

        private Node root;

        private static Node staticRoot;

        public Trie()
        {
            root = new Node(0, 0);
            for (int i = 0; i < 256; i++)
            {
                Init((byte)i);
            }
            staticRoot = root;
        }

        private void Init(byte key)
        {
            var newSubnode = new Node(key, Count);
            root.Subnodes.Add(key, newSubnode);
            newSubnode.Data = Count;
            Count++;
        }

        private (int, bool) AddNode(byte key, ref Node node)
        {
            if (node.TryFind(key) != null)
            {
                node = node.Subnodes[key];
                return (node.Data, false);
            }
            else
            {
                var newSubnode = new Node(key, Count);
                newSubnode.Data = Count;
                node.Subnodes.Add(key, newSubnode);
                Count++;
                return (-1, true);
            }
        }

        /// <summary>
        /// Trying add new symbol to the tree.
        /// </summary>
        /// <param name="key">The symbol we want to add to the tree.</param>
        /// <returns>"-1" - symbol is already there, else - last result.</returns>
        public int TryAdd(byte key)
        {
            (var result, var isChanged) = AddNode(key, ref root);
            if (!isChanged)
            {
                LastResult = result;
                return -1;
            }
            else
            {
                root = staticRoot;
                return LastResult;
            }
        }

        /// <summary>
        /// Get the last result manually.
        /// </summary>
        /// <returns>The last result.</returns>
        public int GetLastResult()
            => LastResult;
    }
}