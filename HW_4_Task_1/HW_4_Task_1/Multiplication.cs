namespace HW_4_Task_1
{
    class Multiplication : Operator
    {
        public Multiplication(INode LeftChild, INode RightChild)
        {
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
        }

        public override string Operation => "*";

        public override double Calculate()
            => LeftChild.Calculate() * RightChild.Calculate();
    }
}
