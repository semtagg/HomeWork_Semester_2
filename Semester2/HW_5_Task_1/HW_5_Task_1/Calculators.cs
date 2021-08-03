using System;

namespace HW_5_Task_1
{
    /// <summary>
    /// A calculator that can сalculates the value of simple expression.
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        public Calculator(IStack stack)
            => this.stack = stack;

        private string[] GetArrayOfSymbols(string inputline)
            => inputline.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        /// <summary>
        /// Calculates the value of the expression.
        /// </summary>
        /// <param name="inputLine">An expression to calculate.</param>
        /// <returns>Value of expression.</returns>
        public double GetResult(string inputLine)
        {
            var symbolsArray = GetArrayOfSymbols(inputLine);
            for (int i = 0; i < symbolsArray.Length; i++)
            {
                if (double.TryParse(symbolsArray[i], out double current))
                {
                    stack.Push(current);
                }
                else
                {
                    var firstItem = stack.Pop();
                    var secondItem = stack.Pop();
                    switch (symbolsArray[i])
                    {
                        case "+":
                            stack.Push(firstItem + secondItem);
                            break;
                        case "-":
                            stack.Push(secondItem - firstItem);
                            break;
                        case "*":
                            stack.Push(firstItem * secondItem);
                            break;
                        case "/":
                            if (Math.Abs(firstItem) < 10e-6)
                            {
                                throw new DivideByZeroException("Attempt to divide by zero!");
                            }
                            stack.Push(secondItem / firstItem);
                            break;
                    }
                }
            }
            var result = stack.Pop();
            return !stack.IsEmpty() ? throw new InvalidOperationException("Array is not empty!") : result;
        }
    }
}