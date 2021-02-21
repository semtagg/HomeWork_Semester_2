using System;

namespace HW_2_Task_2
{
    class ListCalc : Node, IStack
    {
        private Node root;

        public bool IsEmpty()
            => root == null;

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new NotImplementedException("Array is empty!");
            }
            var element = root.item;
            root = root.nextNode;
            return element;
        }

        public void Push(double element)
            => root = new Node(element, root);
    }
}
