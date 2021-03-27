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
            root = null;
        }

        private class Node
        {
            public Node(int degree, bool leaf)
            {
                IsLeaf = leaf;
                Subnodes = new Node[2 * degree];
                KeysValues = new (string, string)[2 * degree - 1];
            }

            public int KeysCount { get; set; }

            public bool IsLeaf { get; set; }

            public Node[] Subnodes { get; set; }

            public (string Key, string Value)[] KeysValues { get; set; }
        }

        private bool RootIsEmpty()
            => root == null ? true : false;

        private int KeysCompare(string firstKey, string secondKey)
            => firstKey.Length > secondKey.Length ? 1 : (firstKey.Length < secondKey.Length ? -1 : String.Compare(firstKey, secondKey));

        private void RootSplit(ref Node node)
        {
            var leftPart = new Node(minimumDegree, true);
            var rightPart = new Node(minimumDegree, true);
            if (!node.IsLeaf)
            {
                leftPart.IsLeaf = false;
                rightPart.IsLeaf = false;
            }


            for (int i = 0; i < minimumDegree; i++)
            {
                if (node.IsLeaf)
                {
                    if (i < minimumDegree - 1)
                    {
                        leftPart.KeysCount++;
                        leftPart.KeysValues[i] = node.KeysValues[i];
                        rightPart.KeysCount++;
                        rightPart.KeysValues[i] = node.KeysValues[minimumDegree + i];
                    }
                }
                else
                {
                    if (i < minimumDegree - 1)
                    {
                        leftPart.KeysCount++;
                        leftPart.KeysValues[i] = node.KeysValues[i];
                        rightPart.KeysCount++;
                        rightPart.KeysValues[i] = node.KeysValues[minimumDegree + i];
                    }
                    leftPart.Subnodes[i] = node.Subnodes[i];
                    rightPart.Subnodes[i] = node.Subnodes[minimumDegree + i];
                }
            }

            var root = new Node(minimumDegree, false);
            
            root.KeysCount = 1;

            root.KeysValues[0] = node.KeysValues[minimumDegree - 1];

            root.Subnodes[0] = leftPart;
            root.Subnodes[1] = rightPart;

            node = root;
        }

        private void NodeSplit(int index, ref Node node, bool isLeaf)
        {
            var leftPart = new Node(minimumDegree, isLeaf);
            var rightPart = new Node(minimumDegree, isLeaf);

            for (int i = 0; i < minimumDegree; i++)
            {
                if (i < minimumDegree - 1)
                {
                    leftPart.KeysValues[i] = (node.Subnodes[index]).KeysValues[i];
                    leftPart.KeysCount++;
                    rightPart.KeysValues[i] = (node.Subnodes[index]).KeysValues[minimumDegree + i];
                    rightPart.KeysCount++;
                }
                
                leftPart.Subnodes[i] = (node.Subnodes[index]).Subnodes[i];
                rightPart.Subnodes[i] = (node.Subnodes[index]).Subnodes[minimumDegree + i];
            }

            node.KeysCount++;

            node.KeysValues[index] = (node.Subnodes[index]).KeysValues[minimumDegree - 1];

            node.Subnodes[index] = leftPart;
            node.Subnodes[index + 1] = rightPart;
        }

        private void InsertInNode((string key, string value) keyValue, ref Node node)
        {
            if (node.IsLeaf)
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.KeysValues[i].Key, keyValue.key) >= 0) // = ??
                    {
                        for (int j = node.KeysCount; j > i; j--)
                        {
                            node.KeysValues[j] = node.KeysValues[j - 1];
                        }
                        node.KeysValues[i] = keyValue;
                        node.KeysCount++;
                        return;
                    }
                    else if ((i == node.KeysCount - 1) && (KeysCompare(node.KeysValues[i].Key, keyValue.key) < 0))
                    {
                        node.KeysValues[i + 1] = keyValue;
                        node.KeysCount++;
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.KeysValues[i].Key, keyValue.key) >= 0) // = ??
                    {
                        if ((node.Subnodes[i]).KeysCount == 2 * minimumDegree - 1)
                        {
                            for (int j = node.KeysCount; j > i; j--)
                            {
                                node.KeysValues[j] = node.KeysValues[j - 1];
                            }
                            node.Subnodes[node.KeysCount + 1] = node.Subnodes[node.KeysCount];
                            NodeSplit(i, ref node, node.Subnodes[i].IsLeaf);
                            InsertInNode(keyValue, ref node);
                            return;
                        }
                        else
                        {
                            InsertInNode(keyValue, ref node.Subnodes[i]);
                            return;
                        }
                    }
                    else if ((i == node.KeysCount - 1) && (KeysCompare(node.KeysValues[i].Key, keyValue.key) < 0))
                    {
                        if ((node.Subnodes[i + 1]).KeysCount == 2 * minimumDegree - 1)
                        {
                            node.Subnodes[node.KeysCount + 1] = node.Subnodes[node.KeysCount];
                            NodeSplit(i + 1, ref node, node.Subnodes[i + 1].IsLeaf);
                            InsertInNode(keyValue, ref node);
                            return;
                        }
                        else
                        {
                            InsertInNode(keyValue, ref node.Subnodes[i + 1]);
                            return;
                        }
                    }
                }
            }
        }

        private void InsertInTree((string key, string value) keyValue, ref Node root) // изменять равные ключи ??
        {
            if (RootIsEmpty())
            {
                root = new Node(minimumDegree, true);
                root.KeysValues[0] = keyValue;
                root.Subnodes = null;
                root.KeysCount++;
            }
            else if (root.KeysCount == (2 * minimumDegree - 1))
            {
                RootSplit(ref root);
                InsertInNode(keyValue, ref root);
            }
            else
            {
                InsertInNode(keyValue, ref root);
            }
        }

        public void Insert(string key, string value)
        {
            InsertInTree((key, value), ref root);
        }
    }
}

//Stuff:

/*

else if (root.KeysCount == (2 * minimumDegree - 1))
{
    NodeSplit(ref root);
    InsertByKey(keyValue, ref root);
}
else if (!root.IsLeaf)
{
    for (int i = 0; i < root.KeysCount; i++)
    {
        if ((KeysCompare(root.KeysValues[i].Key, keyValue.key) > 0))
        {
            InsertByKey(keyValue, ref root.Subnodes[i]);
        }
        else if (i == root.KeysCount - 1)
        {
            InsertByKey(keyValue, ref root.Subnodes[root.KeysCount]);
        }
    }
}
else if (root.KeysCount < (2 * minimumDegree - 1))
{
    for (int i = 0; i < root.KeysCount; i++)
    {
        if (KeysCompare(root.KeysValues[i].Key, keyValue.key) >= 0)
        {
            for (int j = root.KeysCount - 1; j > i; j++)
            {
                root.KeysValues[j] = root.KeysValues[j - 1];
            }
            root.KeysValues[i] = keyValue;
            root.KeysCount++;
            return;
        }
        else if ((i == root.KeysCount - 1) && (KeysCompare(root.KeysValues[i].Key, keyValue.key) < 0))
        {
            root.KeysValues[root.KeysCount] = keyValue;
            root.KeysCount++;
            return;
        }
    }
}*/