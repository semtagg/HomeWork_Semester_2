using System;
using System.Collections.Generic;
using System.Text;

namespace HW_4_Task_2
{
    class List
    {
        protected class ListNode
        {
            public ListNode NextNode { get; set; }

            public int Value { get; set; }

            public ListNode(int value)
            {
                Value = value;
                NextNode = null;
            }
        }

        private ListNode root;
        private ListNode head;
        private int listSize = 0;

        protected bool IndexCheck(int index)
        {
            if ((index < 0) || (listSize < index))
            {
                return false;
            }
            return true;
        }

        private void SearchByIndex(int index)
        {
            root = head;
            while (0 != index)
            {
                root = root.NextNode;
                index--;
            }
        }

        protected ListNode SearchByValue(int value)
        {
            root = head;
            while ((root.Value != value) || (root != null))
            {
                root = root.NextNode;
            }
            return root;
        }

        public virtual void InsertByIndex(int value, int index)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            if (root == null)
            {
                root = new ListNode(value);
                head = root;
                listSize++;
            }
            else
            {
                SearchByIndex(index);
                var helpElement = root.NextNode;
                root.NextNode = new ListNode(value);
                (root.NextNode).NextNode = helpElement;
                listSize++;
            }
        }

        public void RemoveByIndex(int index)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            SearchByIndex(index - 1);
            var helpElement = root.NextNode;
            root.NextNode = (root.NextNode).NextNode;
            helpElement = null;
        }

        public void ChangeByIndex(int index, int value)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            SearchByIndex(index);
            root.Value = value;
        }

        public void RemoveByValue(int value)
        {
            root = SearchByValue(value);
            if (root == null)
            {
                // кинуть ошибку из созданного класса
            }
            else
            {
                var helpElement = root.NextNode;
                root.NextNode = (root.NextNode).NextNode;
                helpElement = null; 8
            }
        }
    }
}
