using System;
using System.Collections.Generic;
using System.Text;

namespace HW_2_Task_1
{
    class Trie<T>
    {
        class Node<T>
        {
            public char Symbol { get; set; }
            public T Data { get; set; }
            public bool IsWord { get; set; }
            public string Prefix { get; set; }

            public Dictionary<char, Node<T>> SubNodes { get; set; }

            public Node(char symbol, T data)
            {
                Symbol = symbol;
                Data = data;
                SubNodes = new Dictionary<char, Node<T>>();
            }

            public Node<T> TryFind(char symbol)
            {
                if (SubNodes.TryGetValue(symbol, out Node<T> value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }

            public override string ToString()
            {
                return Data.ToString();
            }

            public override bool Equals(object obj)
            {
                if (obj is Node<T> item)
                {
                    return Data.Equals(item);
                }
                else
                {
                    return false;
                }
            }
        }
        private Node<T> root;
        public int Count { get; set; }
        public Trie()
        {
            root = new Node<T>('\0', default(T));
            Count = 1;
        }

        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                }
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFind(symbol);
                if (subnode != null)
                {
                    AddNode(key.Substring(1), data, subnode);
                }
                else
                {
                    var newNode = new Node<T>(symbol, data);
                    node.SubNodes.Add(symbol, newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
            }
        }

        public void Add(string key, T data)
        {
            AddNode(key, data, root);
        }

        private void RemoveNode(string key, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    RemoveNode(key.Substring(1), subnode);
                }
            }
        }

        public void Remove(string key)
        {
            RemoveNode(key, root);
        }
        private bool SearchNode(string key, Node<T> node, out T value)
        {
            value = default(T);
            var result = false;
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    value = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFind(key[0]);
                if (subnode != null)
                {
                    result = SearchNode(key.Substring(1), subnode, out value);
                }
            }
            return result;
        }
        public bool Search(string key, out T value)
        {
            return SearchNode(key, root, out value);
        }
    }
}

// key - все слово
// symbol - один символ