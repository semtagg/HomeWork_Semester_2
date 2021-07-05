using System;

namespace HW_4_Task_1
{
    class Division : Operator
    {
        public Division(INode LeftChild, INode RightChild)
        {
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
        }

        public override string Operation => "/";

        public override double Calculate()
            => Math.Abs(RightChild.Calculate()) <= 10e-6 ? throw new DivideByZeroException() : LeftChild.Calculate() / RightChild.Calculate();
    }
}
