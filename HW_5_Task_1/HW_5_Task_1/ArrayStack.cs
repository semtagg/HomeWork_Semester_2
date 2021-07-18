using System;

namespace HW_5_Task_1
{
    /// <summary>
    /// Stack implementation based on array.
    /// </summary>
    public class ArrayStack : IStack
    {
        private int index = -1;
        private double[] array = new double[2];

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        public bool IsEmpty()
            => index == -1;

        /// <summary>
        /// Deletes an item from the stack.
        /// </summary>
        public double Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Array is empty!");
            }
            index--;
            return array[index + 1];
        }

        /// <summary>
        /// Adds an item to the stack.
        /// </summary>
        /// <param name="element">Item value.</param>
        public void Push(double element)
        {
            if (array.Length - 1 <= index)
            {
                Array.Resize(ref array, array.Length * 2);
            }
            index++;
            array[index] = element;
        }
    }
}