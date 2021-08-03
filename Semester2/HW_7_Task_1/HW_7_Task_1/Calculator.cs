using System;

namespace HW_7_Task_1
{
    /// <summary>
    /// A class that implements calculations.
    /// </summary>
    public class Calculator
    {
        private static string[] operations = { "+", "-", "*", "/" };
        private string firstOperand;
        private string secondOperand;
        private string operation;
        private string result;

        private bool IsOperation(string symbol)
            => Array.IndexOf(operations, symbol) != -1;

        private void EnteredNumber(string symbol)
        {
            if (operation == null)
            {
                firstOperand += symbol;
            }
            else
            {
                secondOperand += symbol;
            }
            result += symbol;
        }

        private void EnteredOperation(string symbol)
        {
            if (firstOperand != null && secondOperand != null)
            {
                result = Calculate();
                firstOperand = result;
                secondOperand = null;
                operation = symbol;
                result += symbol;
            }
            else if (firstOperand == null && symbol == "-")
            {
                firstOperand += symbol;
                result += symbol;
            }
            else if (firstOperand != null && firstOperand != "-")
            {
                if (operation == null)
                {
                    result += symbol;
                    operation = symbol;
                }
                else
                {
                    result = result[..(result.Length - 1)] + symbol;
                    operation = symbol;
                }
            }
        }

        private void EnteredEqualSign(string symbol)
        {
            if (firstOperand != null && secondOperand != null)
            {
                result = Calculate();
                firstOperand = result;
                secondOperand = null;
                operation = null;
            }
            else if (firstOperand != null && firstOperand != "-")
            {
                if (operation != null)
                {
                    result = result[..(result.Length - 1)];
                    operation = null;
                }
            }
        }

        private string Calculate()
        {
            var currentResult = "";
            switch (operation)
            {
                case "+":
                    currentResult = (double.Parse(firstOperand) + double.Parse(secondOperand)).ToString();
                    Default();
                    break;
                case "-":
                    currentResult = (double.Parse(firstOperand) - double.Parse(secondOperand)).ToString();
                    Default();
                    break;
                case "*":
                    currentResult = (double.Parse(firstOperand) * double.Parse(secondOperand)).ToString();
                    Default();
                    break;
                case "/":
                    if (Math.Abs(double.Parse(secondOperand)) < 10e-6)
                    {
                        throw new DivideByZeroException();
                    }
                    currentResult = (double.Parse(firstOperand) / double.Parse(secondOperand)).ToString();
                    Default();
                    break;
            }
            return currentResult;
        }

        /// <summary>
        /// Attempts to perform calculations on the entered character.
        /// </summary>
        public string TryCalculate(string symbol)
        {
            if (IsOperation(symbol))
            {
                EnteredOperation(symbol);
            }
            else if (symbol == "=")
            {
                EnteredEqualSign(symbol);
            }
            else
            {
                EnteredNumber(symbol);
            }
            return result;
        }

        /// <summary>
        /// Sets the default values for the fields.
        /// </summary>
        public void Default()
            => result = operation = firstOperand = secondOperand = null;
    }
}
