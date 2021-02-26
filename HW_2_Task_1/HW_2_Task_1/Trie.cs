using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2_Task_1
{
    class Trie
    {
        class Node
        {
            public char Symbol { get; set; }
            public byte Index { get; set; }
            public bool IsWord { get; set; }
            public byte Data { get; set; }

            public Dictionary<char, Node> SubNodes { get; set; }

            public Node(char symbol, byte index)
            {
                Symbol = symbol;
                Index = index;
                SubNodes = new Dictionary<char, Node>();
            }

            public Node TryFind(char symbol)
            {
                if (SubNodes.TryGetValue(symbol, out Node value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
        }
        private Node root;
        public Trie()
        {
            root = new Node('\0', default(byte));
        }

        private (byte, bool) AddNode(string key, ref byte data, Node node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                    data++;
                    return (node.Data, !node.IsWord);
                }
                else
                {
                    return (node.Data, !node.IsWord);
                }
                
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    return AddNode(key.Substring(1), ref data, subnode);
                }
                else
                {
                    var newNode = new Node(symbol, data);
                    node.SubNodes.Add(symbol, newNode);
                    return AddNode(key[1..],ref data, newNode);
                }
            }
        }
        private byte data;
        public (byte, bool) Add(string key)
        {
            return AddNode(key, ref data, root);
        }
    }
}
