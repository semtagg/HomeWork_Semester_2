
namespace HW_4_Task_1
{
    /// <summary>
    /// A class for the addition operator.
    /// </summary>
    class Addition : Operator
    {
        public Addition(INode LeftChild, INode RightChild)
        {
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
        }

        public override string Operation => "+";

        public override double Calculate()
            => LeftChild.Calculate() + RightChild.Calculate();
    }
}
