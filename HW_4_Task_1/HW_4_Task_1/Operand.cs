using System;

namespace HW_4_Task_1
{
    /// <summary>
    /// Tree node for expression operands.
    /// </summary>
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
