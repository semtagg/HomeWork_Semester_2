using System;

namespace HW_3_Task_1
{
    public class BTree
    {
        private int height;
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
            height = 0;
        }

        private class Node
        {
            public Node(int degree, bool leaf)
            {
                IsLeaf = leaf;
                Subnodes = new Node[2 * degree];
                Data = new (string, string)[2 * degree - 1];
            }

            public int KeysCount { get; set; }

            public bool IsLeaf { get; set; }

            public Node[] Subnodes { get; set; }

            public (string Key, string Value)[] Data { get; set; }
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
                        leftPart.Data[i] = node.Data[i];
                        rightPart.KeysCount++;
                        rightPart.Data[i] = node.Data[minimumDegree + i];
                    }
                }
                else
                {
                    if (i < minimumDegree - 1)
                    {
                        leftPart.KeysCount++;
                        leftPart.Data[i] = node.Data[i];
                        rightPart.KeysCount++;
                        rightPart.Data[i] = node.Data[minimumDegree + i];
                    }
                    leftPart.Subnodes[i] = node.Subnodes[i];
                    rightPart.Subnodes[i] = node.Subnodes[minimumDegree + i];
                }
            }
            var root = new Node(minimumDegree, false);
            root.KeysCount = 1;
            root.Data[0] = node.Data[minimumDegree - 1];
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
                    leftPart.Data[i] = (node.Subnodes[index]).Data[i];
                    leftPart.KeysCount++;
                    rightPart.Data[i] = (node.Subnodes[index]).Data[minimumDegree + i];
                    rightPart.KeysCount++;
                }
                leftPart.Subnodes[i] = (node.Subnodes[index]).Subnodes[i];
                rightPart.Subnodes[i] = (node.Subnodes[index]).Subnodes[minimumDegree + i];
            }
            node.KeysCount++;
            node.Data[index] = (node.Subnodes[index]).Data[minimumDegree - 1];
            node.Subnodes[index] = leftPart;
            node.Subnodes[index + 1] = rightPart;
        }

        private void InsertInNode((string key, string value) keyValue, ref Node node)
        {
            if (node.IsLeaf)
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, keyValue.key) > 0)
                    {
                        for (int j = node.KeysCount; j > i; j--)
                        {
                            node.Data[j] = node.Data[j - 1];
                        }
                        node.Data[i] = keyValue;
                        node.KeysCount++;
                        return;
                    }
                    else if ((i == node.KeysCount - 1) && (KeysCompare(node.Data[i].Key, keyValue.key) < 0))
                    {
                        node.Data[i + 1] = keyValue;
                        node.KeysCount++;
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, keyValue.key) > 0)
                    {
                        if ((node.Subnodes[i]).KeysCount == 2 * minimumDegree - 1)
                        {
                            for (int j = node.KeysCount; j > i; j--)
                            {
                                node.Data[j] = node.Data[j - 1];
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
                    else if ((i == node.KeysCount - 1) && (KeysCompare(node.Data[i].Key, keyValue.key) < 0))
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

        private void InsertInTree((string key, string value) keyValue, ref Node root)
        {
            if (RootIsEmpty())
            {
                root = new Node(minimumDegree, true);
                root.Data[0] = keyValue;
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
            if (height < TryFindKey(keyValue.key, root).Height)
            {
                height = TryFindKey(keyValue.key, root).Height;
            }
        }

        public void Insert(string key, string value)
        {
            InsertInTree((key, value), ref root);
        }

        private (bool Status, int Height) TryFindKey(string key, Node node)
        {
            if (node.IsLeaf)
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, key) == 0)
                    {
                        return (true, 1);
                    }
                }
                return (false, 0);
            }
            else
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, key) == 0)
                    {
                        return (true, 1);
                    }
                    if (KeysCompare(node.Data[i].Key, key) > 0)
                    {
                        return (TryFindKey(key, node.Subnodes[i]).Status, TryFindKey(key, node.Subnodes[i]).Height + 1);
                    }
                }
                return (TryFindKey(key, node.Subnodes[node.KeysCount]).Status, TryFindKey(key, node.Subnodes[node.KeysCount]).Height + 1);
            }
        }

        public bool CheckKey(string key)
        {
            if (RootIsEmpty())
            {
                throw new NullReferenceException("Root is empty.");
            }
            else
            {
                return TryFindKey(key, root).Status;
            }
        }

        private string GetValueByIndex(string key, Node node)
        {
            if (node.IsLeaf)
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, key) == 0)
                    {
                        return node.Data[i].Value;
                    }
                }
                return null;
            }
            else
            {
                for (int i = 0; i < node.KeysCount; i++)
                {
                    if (KeysCompare(node.Data[i].Key, key) == 0)
                    {
                        return node.Data[i].Value;
                    }
                    if (KeysCompare(node.Data[i].Key, key) > 0)
                    {
                        return GetValueByIndex(key, node.Subnodes[i]);
                    }
                }
                return GetValueByIndex(key, node.Subnodes[node.KeysCount]);
            }
        }

        public string GetValue(string key)
        {
            if (RootIsEmpty())
            {
                throw new NullReferenceException("Root is empty");
            }
            else if (CheckKey(key))
            {
                return GetValueByIndex(key, root);
            }
            else
            {
                throw new ArgumentNullException("Key not found.");
            }
        }

        private void RemoveFromRootrOrNormalNode(string key, ref Node root)
        {
            for (int i = 0; i < root.KeysCount; i++)
            {
                if (KeysCompare(root.Data[i].Key, key) == 0)
                {
                    for (int j = i; j < root.KeysCount - 1; j++)
                    {
                        var swap = root.Data[j];
                        root.Data[j] = root.Data[j + 1];
                        root.Data[j + 1] = swap;
                    }
                    root.Data[root.KeysCount - 1] = (null, null);
                    root.KeysCount--;
                    return;
                }
            }
        }

        private void NodeMerge(int index, ref Node node)
        {
            int count;
            if (node == root && node.KeysCount == 1)
            {
                count = (node.Subnodes[0]).KeysCount;
                (node.Subnodes[0]).Data[count] = node.Data[0];

                for (int i = count + 1; i < 2 * count + 1; i++)
                {
                    (node.Subnodes[0]).Data[i] = (node.Subnodes[1]).Data[i - count - 1];
                    (node.Subnodes[0]).Subnodes[i] = (node.Subnodes[1]).Subnodes[i - count - 1];
                }
                (node.Subnodes[0]).Subnodes[2 * count + 1] = (node.Subnodes[1]).Subnodes[count];
                (node.Subnodes[0]).KeysCount = 2 * count + 1;
                node = node.Subnodes[0];
            }
            else
            {
                count = (node.Subnodes[index]).KeysCount;
                (node.Subnodes[index]).Data[count] = node.Data[index];

                for (int i = count + 1; i < 2 * count + 1; i++)
                {
                    (node.Subnodes[index]).Data[i] = (node.Subnodes[index + 1]).Data[i - count - 1];
                    (node.Subnodes[index]).Subnodes[i] = (node.Subnodes[index + 1]).Subnodes[i - count - 1];
                }
                (node.Subnodes[index]).Subnodes[2*count + 1] = (node.Subnodes[index + 1]).Subnodes[count];
                (node.Subnodes[index]).KeysCount = 2 * count + 1;

                node.Subnodes[index + 1] = node.Subnodes[index];
                for (int j = index; j < node.KeysCount - 1; j++)
                {
                    node.Data[j] = node.Data[j + 1];
                    node.Subnodes[j] = node.Subnodes[j + 1];
                }
                node.Subnodes[node.KeysCount - 1] = node.Subnodes[node.KeysCount];
                node.Data[node.KeysCount - 1] = (null, null);
                node.Subnodes[node.KeysCount] = null;
                node.KeysCount--;
            }
        }

        private void NodeSwitch(int index, ref Node node, bool isRight)
        {
            Node element;
            int indexCount;
            int rotateCount;
            if (isRight)
            {
                indexCount = (node.Subnodes[index]).KeysCount;
                rotateCount = (node.Subnodes[index - 1]).KeysCount;

                element = (node.Subnodes[index - 1]).Subnodes[rotateCount];

                for (int i = indexCount; i > 0; i--)
                {
                    (node.Subnodes[index]).Data[i] = (node.Subnodes[index]).Data[i - 1];
                    (node.Subnodes[index]).Subnodes[i] = (node.Subnodes[index]).Subnodes[i - 1];
                }
                
                (node.Subnodes[index]).Data[0] = node.Data[index - 1];
                node.Data[index - 1] = (node.Subnodes[index - 1]).Data[rotateCount - 1];

                (node.Subnodes[index]).Subnodes[0] = element;
                (node.Subnodes[index]).KeysCount++;

                (node.Subnodes[index - 1]).Subnodes[rotateCount] = null;
                (node.Subnodes[index - 1]).Data[rotateCount - 1] = (null, null);
                (node.Subnodes[index - 1]).KeysCount--;

            }
            else
            {
                indexCount = (node.Subnodes[index]).KeysCount;
                rotateCount = (node.Subnodes[index + 1]).KeysCount;

                element = (node.Subnodes[index + 1]).Subnodes[0];

                (node.Subnodes[index]).Data[indexCount] = node.Data[index];
                node.Data[index] = (node.Subnodes[index + 1]).Data[0];

                for (int i = 0; i < rotateCount - 1; i++)
                {
                    (node.Subnodes[index + 1]).Data[i] = (node.Subnodes[index + 1]).Data[i + 1];
                    (node.Subnodes[index + 1]).Subnodes[i] = (node.Subnodes[index + 1]).Subnodes[i + 1];
                }
                (node.Subnodes[index + 1]).Subnodes[rotateCount - 1] = (node.Subnodes[index + 1]).Subnodes[rotateCount];
                (node.Subnodes[index]).Subnodes[indexCount + 1] = element;
                (node.Subnodes[index]).KeysCount++;

                (node.Subnodes[index + 1]).Subnodes[rotateCount] = null;
                (node.Subnodes[index + 1]).Data[rotateCount - 1] = (null, null);
                (node.Subnodes[index + 1]).KeysCount--;
            }
        }

        private void RemoveFromLeaf(string key, ref Node node, int height)
        {
            int index;
            if (node == root && node.IsLeaf)
            {
                RemoveFromRootrOrNormalNode(key, ref root);
                if (root.KeysCount == 0)
                {
                    root = null;
                }
                this.height = 1;
                return;
            }
            if (height != 2)
            {
                index = 0;
                while (index < node.KeysCount && KeysCompare(node.Data[index].Key, key) < 0) //  ?
                {
                    index++;
                }
                if (node.Subnodes[index].KeysCount == 1)
                {
                    if (index == 0)
                    {
                        if (node.Subnodes[1].KeysCount < minimumDegree)
                        {
                            NodeMerge(index, ref node);
                            if (node == root)
                            {
                                height--;
                                this.height--;
                            }
                            RemoveFromLeaf(key, ref node, height);
                            return;
                        }
                        else
                        {
                            NodeSwitch(index, ref node, false);
                            RemoveFromLeaf(key, ref node, height);
                            return;
                        }
                    }
                    else
                    {
                        if (node.Subnodes[0].KeysCount < minimumDegree)
                        {
                            NodeMerge(index, ref node);
                            if (node == root)
                            {
                                height--;
                                this.height--;
                            }
                            RemoveFromLeaf(key, ref node, height);
                            return;
                        }
                        else
                        {
                            NodeSwitch(index, ref node, false);
                            RemoveFromLeaf(key, ref node, height);
                            return;
                        }
                    }
                }
                RemoveFromLeaf(key, ref node.Subnodes[index], height - 1);
            }
            else
            {
                index = 0;
                while (index < node.KeysCount && KeysCompare(node.Data[index].Key, key) < 0) //  с последним вопрос
                {
                    index++;
                }
                if (node.Subnodes[index].KeysCount >= minimumDegree)
                {
                    RemoveFromRootrOrNormalNode(key, ref node.Subnodes[index]);
                    return;
                }
                else if (index == 0)
                {
                    if (node.Subnodes[index + 1].KeysCount < minimumDegree)
                    {
                        NodeMerge(index, ref node);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                    else
                    {
                        NodeSwitch(index, ref node, false);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                }
                else if (index == node.KeysCount)
                {
                    if (node.Subnodes[index - 1].KeysCount < minimumDegree)
                    {
                        NodeMerge(index - 1, ref node);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                    else
                    {
                        NodeSwitch(index, ref node, true);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                }
                else if ((node.Subnodes[index - 1].KeysCount < minimumDegree) && (node.Subnodes[index + 1].KeysCount < minimumDegree))
                {
                    NodeMerge(index, ref node);
                    RemoveFromLeaf(key, ref node, height);
                    return;
                }
                else
                {
                    if (node.Subnodes[index - 1].KeysCount >= minimumDegree)
                    {
                        NodeSwitch(index, ref node, true);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                    else
                    {
                        NodeSwitch(index, ref node, false);
                        RemoveFromLeaf(key, ref node, height);
                        return;
                    }
                }
            }
        }

        public void Remove(string key)
        {
            if (RootIsEmpty())
            {
                throw new NullReferenceException("Root is empty");
            }
            else if (!CheckKey(key))
            {
                throw new ArgumentNullException("Key not found.");
            }
            else
            {
                var height = TryFindKey(key, root).Height;
                if (height == 1 && this.height == height)
                {
                    RemoveFromRootrOrNormalNode(key, ref root);
                    if (root.KeysCount == 0)
                    {
                        root = null;
                    }
                }
                else if (this.height == height)
                {
                    RemoveFromLeaf(key, ref root, height);
                }
                else
                {

                }
            }
        }
    }
}