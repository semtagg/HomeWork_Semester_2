using System;

namespace HW_5_Task_1
{
    /// <summary>
    /// Stack implementation based on list.
    /// </summary>
    public class ListStack : IStack
    {
        private class Node
        {
            public Node(double item, Node nextNode)
            {
                this.item = item;
                this.nextNode = nextNode;
            }

            public double item;
            public Node nextNode;
        }

        private Node head;

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        public bool IsEmpty()
            => head == null;

        /// <summary>
        /// Deletes an item from the stack.
        /// </summary>
        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Array is empty!");
            }
            var element = head.item;
            head = head.nextNode;
            return element;
        }

        /// <summary>
        /// Adds an item to the stack.
        /// </summary>
        /// <param name="element">Item value.</param>
        public void Push(double element)
            => head = new Node(element, head);
    }
}