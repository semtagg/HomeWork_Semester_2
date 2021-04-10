using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7_Task_1
{
    class Calculator
    {
        private static char[] operations = { '+', '-', '*', '/', '=' };
        private string[] operands;
        private char operation;
        private string result;

        public Calculator()
        {
            operands = new string[2];
        }

        private bool IsOperation(char symbol)
            => Array.IndexOf(operations, symbol) == -1 ? false : true;

        public string TryCalculate(char symbol)
        {
            if (IsOperation(symbol))
            {
                if (operands[0] != null && operands[1] != null)
                {
                    try
                    {

                    }
                    catch (Exception)
                    {
                        throw new DivideByZeroException();
                    }
                }
                else
                {
                    if (operation == default(char))
                    {
                        result += symbol;
                    }
                    else
                    {

                    }
                }
            }
            else
            {

            }
            return result;
        }

        private string Calculate(char symbol)
        {
            string currentResult = "";
            switch (symbol)
            {
                case '+':
                    currentResult = (int.Parse(operands[0]) + int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case '-':
                    currentResult = (int.Parse(operands[0]) - int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case '*':
                    currentResult = (int.Parse(operands[0]) * int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case '/':
                    if (int.Parse(operands[1]) == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    currentResult = (int.Parse(operands[0]) / int.Parse(operands[1])).ToString();
                    Default();
                    break;
            }
            return currentResult;
        }

        private void Default()
        {
            operation = default(char);
            operands[0] = operands[1] = null;
        }
    }
}
