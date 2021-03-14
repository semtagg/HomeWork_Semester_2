using System;

namespace HW_4_Task_2
{
    /// <summary>
    /// Abstract data type that represents a countable number of ordered values.
    /// </summary>
    public class List
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
            while (root != null)
            {
                if ((root.NextNode != null) &&((root.NextNode).Value == value))
                {
                    return root;
                }
                root = root.NextNode;
            }
            return root;
        }

        /// <summary>
        /// Inserts the value of the new element by the index.
        /// </summary>
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
                SearchByIndex(index - 1);
                var helpElement = root.NextNode;
                root.NextNode = new ListNode(value);
                (root.NextNode).NextNode = helpElement;
                listSize++;
            }
        }

        /// <summary>
        /// Removes the value of the element by the index.
        /// </summary>
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

        /// <summary>
        /// Changes the value of the element by the index.
        /// </summary>
        public void ChangeByIndex(int value, int index)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            SearchByIndex(index);
            root.Value = value;
        }

        /// <summary>
        /// Tries to remove an element by the index.
        /// </summary>
        public void RemoveByValue(int value)
        {
            if (root == head)
            {
                head = null;
                root = head;
            }
            else
            {
                root = SearchByValue(value);
                if (root == null)
                {
                    throw new DeleteElementException("Element not exist.");
                }
                else
                {
                    var helpElement = root.NextNode;
                    root.NextNode = (root.NextNode).NextNode;
                    helpElement = null;
                }
            }
                
        }

        /// <summary>
        /// Returns value of the last element.
        /// </summary>
        public int GetLastValue()
        {
            root = head;
            while (root.NextNode != null)
            {
                root = root.NextNode;
            }
            return root.Value;
        }

        /// <summary>
        /// Returns value of the element by the index.
        /// </summary>
        public int GetValueByIndex(int index)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            SearchByIndex(index);
            return root.Value;
        }

        protected bool CheckValue(int value)
        {
            root = head;
            while (root != null)
            {
                if (root.Value == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
