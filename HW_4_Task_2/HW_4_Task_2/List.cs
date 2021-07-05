using System;

namespace HW_4_Task_2
{
    /// <summary>
    /// Abstract data type that represents a countable number of ordered values.
    /// </summary>
    public class List
    {
        private class ListNode
        {
            public ListNode NextNode { get; set; }

            public int Value { get; set; }

            public ListNode(int value)
            {
                Value = value;
                NextNode = null;
            }

            public ListNode(int value, ListNode next)
            {
                Value = value;
                NextNode = next;
            }
        }

        private ListNode head;
        private int listSize = 0;

        private bool CheckIndex(int index)
            => index < 0 || listSize < index ? false : true;

        private ListNode SearchByIndex(int index)
        {
            var root = head;
            while (index != 0)
            {
                root = root.NextNode;
                index--;
            }
            return root;
        }

        /// <summary>
        /// Inserts the value of the new element by the index.
        /// </summary>
        public virtual void Insert(int value, int index)
        {
            if (!CheckIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
            if (head == null)
            {
                head = new(value);
            }
            else
            {
                if (index == 0)
                {
                    head = new(value, head);
                }
                else if (index == listSize)
                {
                    SearchByIndex(index - 1).NextNode = new(value);
                }
                else
                {
                    var helpNode = SearchByIndex(index - 1);
                    ListNode newNode = new(value, SearchByIndex(index).NextNode);
                    helpNode.NextNode = newNode;
                }
            }
            listSize++;
        }

        /// <summary>
        /// Removes the value of the element by the index.
        /// </summary>
        public void Remove(int index)
        {
            if (!CheckIndex(index))
            {
                throw new ElementDoesNotExistException();
            }
            SearchByIndex(index - 1).NextNode = SearchByIndex(index).NextNode;
            listSize--;
        }

        /// <summary>
        /// Changes the value of the element by the index.
        /// </summary>
        public virtual void Change(int value, int index)
        {
            if (!CheckIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
            SearchByIndex(index).Value = value;
        }


        /// <summary>
        /// Searches an element in the list by its value.
        /// </summary>
        /// <returns>Element index or "-1" if the element is not in the list.</returns>
        public int SearchByValue(int value)
        {
            var root = head;
            var index = -1;
            while (root != null)
            {
                index++;
                if (root.Value == value)
                {
                    return index;
                }
                root = root.NextNode;
            }
            return -1;
        }

        /// <summary>
        /// Checks the content of the element in the list.
        /// </summary>
        public bool CheckValue(int value)
        {
            var root = head;
            while (root != null)
            {
                if (root.Value == value)
                {
                    return true;
                }
                root = root.NextNode;
            }
            return false;
        }
    }
}
