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

            public bool IsWord { get; set; }

            public int Index { get; set; }

            public int Data { get; set; }

            public Dictionary<char, Node> subnodes {get; set;}


            public Node(char symbol, int index)
            {
                Symbol = symbol;
                Index = index;
                subnodes = new Dictionary<char, Node>();
            }
            public Node TryFind(char symbol)
            {
                if (subnodes.TryGetValue(symbol, out Node value))
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
            root = new Node('\0', default(int));
        }

        private int count;
        private (int,bool) AddNode(string key, Node node)
        {

            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = count;
                    count++;
                    node.IsWord = true;
                    return (node.Data,true);
                }
                else
                {
                    return (node.Data,false);
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {                   
                    return AddNode(key[1..], subnode);
                }
                else
                {
                    var newSubnode = new Node(symbol, count);
                    node.subnodes.Add(symbol, newSubnode);
                    return AddNode(key[1..], newSubnode);
                }
            }
        }

        public int Add(string key)
        {
            (var result, var isChanged) = AddNode(key, root);
            if (!isChanged)
            {
                return result;
            }
            return -1;
        }
    }
}