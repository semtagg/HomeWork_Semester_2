using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7_Task_1
{
    public class Calculator
    {
        private static string[] operations = { "+", "-", "*", "/", "=" };
        private string[] operands;
        private string operation;
        private string result;

        public Calculator()
        {
            operands = new string[2];
        }

        private bool IsOperation(string symbol)
            => Array.IndexOf(operations, symbol) == -1 ? false : true;

        public string TryCalculate(string symbol)
        {
            if (IsOperation(symbol))
            {
                if (operands[0] != null && operands[1] != null)
                {
                    try
                    {
                        result = Calculate();
                    }
                    catch (Exception)
                    {
                        throw new DivideByZeroException();
                    }
                }
                else
                {
                    if (operation == null)
                    {
                        result += symbol;
                        operation = symbol;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                if (operands[0] == null)
                {
                    operands[0] += symbol;
                }
                else
                {
                    operands[1] += symbol;
                }
                result += symbol;
            }
            return result;
        }

        private string Calculate()
        {
            string currentResult = "";
            switch (operation)
            {
                case "+":
                    currentResult = (int.Parse(operands[0]) + int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case "-":
                    currentResult = (int.Parse(operands[0]) - int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case "*":
                    currentResult = (int.Parse(operands[0]) * int.Parse(operands[1])).ToString();
                    Default();
                    break;
                case "/":
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
            operation = operands[0] = operands[1] = null;
        }
    }
}
