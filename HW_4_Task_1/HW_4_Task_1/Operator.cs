using System;

namespace HW_4_Task_1
{
    /// <summary>
    /// Tree node for expression operators.
    /// </summary>
    abstract class Operator : INode
    {
        public virtual string Operation { get; }

        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }

        public abstract double Calculate();

        /// <summary>
        /// Prints the expression in common form.
        /// </summary>
        public void Print()
        {
            Console.Write($"( {Operation} ");
            LeftChild.Print();
            RightChild.Print();
            Console.WriteLine(") ");
        }
    }
}
