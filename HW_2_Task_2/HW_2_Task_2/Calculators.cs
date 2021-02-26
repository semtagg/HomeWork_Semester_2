using System;

namespace HW_2_Task_2
{
    class Calculator
    {
        private IStack stack;

        public Calculator(IStack stack)
            => this.stack = stack;

        private string[] GetArrayOfSymbols(string inputline)
            => inputline.Split(' ', StringSplitOptions.RemoveEmptyEntries);

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
