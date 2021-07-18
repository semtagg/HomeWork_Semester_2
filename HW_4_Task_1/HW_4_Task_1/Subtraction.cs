
namespace HW_4_Task_1
{
    /// <summary>
    /// A class for the subtraction operator.
    /// </summary>
    class Subtraction : Operator
    {
        public Subtraction(INode LeftChild, INode RightChild)
        {
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
        }

        public override string Operation => "-";

        public override double Calculate()
            => LeftChild.Calculate() - RightChild.Calculate();
    }
}
