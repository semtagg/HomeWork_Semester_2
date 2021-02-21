using System;

namespace HW_2_Task_2
{
    class ArrayCalc : IStack
    {
        private int index = -1;
        private double[] array = new double[1];
        public bool IsEmpty()
            => index == -1;

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new NotImplementedException("Array is empty!");
            }
            index--;
            return array[index + 1];
        }

        public void Push(double element)
        {
            if (array.Length - 1 <= index)
            {
                Array.Resize(ref array, array.Length + 1);
            }
            index++;
            array[index] = element;
        }
    }
}
