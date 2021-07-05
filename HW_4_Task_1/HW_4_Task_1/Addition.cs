using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Task_1
{
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
