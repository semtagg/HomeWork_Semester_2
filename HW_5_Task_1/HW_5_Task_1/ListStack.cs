using System;

namespace HW_5_Task_1
{
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

        public bool IsEmpty()
            => head == null;

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

        public void Push(double element)
            => head = new Node(element, head);
    }
}