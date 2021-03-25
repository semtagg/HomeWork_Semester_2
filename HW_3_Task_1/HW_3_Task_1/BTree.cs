using System;
using System.Collections.Generic;
using System.Text;

namespace HW_3_Task_1
{
    class BTree
    {
        private int minimumDegree;
        private Node root;

        public BTree(int degree)
        {
            if (degree < 2)
            {
                throw new IndexOutOfRangeException();
            }
            minimumDegree = degree;
            root = new Node(degree, null);
        }

        private class Node
        {
            public Node(int degree, Node parent)
            {
                Parent = parent;
                KeysCount = 2 * degree; // ?
                IsLeaf = true;
                Subnodes = new Node[2 * degree + 1];
                KeysValues = new (string, string)[2 * degree];
            }

            public Node Parent { get; set; }

            public int KeysCount { get; set; }

            public bool IsLeaf { get; set; }

            public Node[] Subnodes { get; set; }

            public (string, string)[] KeysValues { get; set; }
        }


    }
}
