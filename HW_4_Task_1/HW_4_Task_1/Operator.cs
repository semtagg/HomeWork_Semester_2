using System;

namespace HW_4_Task_1
{
    /// <summary>
    /// Tree node for expression operators.
    /// </summary>
    class Operator : INode
    {
        public string Operation { get; set; }

        public INode LeftChild { get; set; }

        public INode RightChild { get; set; }

        public Operator (string operation, INode leftChild, INode rightChild)
        {
            Operation = operation;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public double Calculate() =>
            Operation switch
            {
                "+" => LeftChild.Calculate() + RightChild.Calculate(),
                "-" => LeftChild.Calculate() - RightChild.Calculate(),
                "*" => LeftChild.Calculate() * RightChild.Calculate(),
                "/" => (Math.Abs(RightChild.Calculate()) < 10e-6) ? throw new DivideByZeroException() : LeftChild.Calculate() / RightChild.Calculate(),
                _ => throw new ArgumentException()
            };

        public void Print()
        {
            Console.Write($"( {Operation} ");
            LeftChild.Print();
            RightChild.Print();
            Console.Write(") ");
        }
    }
}
