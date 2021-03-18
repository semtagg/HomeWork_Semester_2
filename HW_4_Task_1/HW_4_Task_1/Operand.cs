using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Task_1
{
    class Operand : INode
    {
        public double Value { get; set; }

        public Operand(double value)
        {
            Value = value;
        }

        public double Calculate()
            => Value;

        public void Print()
        {
            Console.Write($"{Value} ");
        }
    }
}
