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
                    if (symbol == "=")
                    {
                        try
                        {
                            result = Calculate();
                            operands[0] = result;
                            operands[1] = null;
                            operation = null;
                        }
                        catch (Exception)
                        {
                            Default();
                            throw new DivideByZeroException();
                        }
                    }
                    else
                    {
                        try
                        {
                            result = Calculate();
                            operands[0] = result;
                            operands[1] = null;
                            operation = symbol;
                            result += symbol;
                        }
                        catch (Exception)
                        {
                            Default();
                            throw new DivideByZeroException();
                        }
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
                        result = result[..(result.Length - 1)] + symbol;
                        operation = symbol;
                    }
                }
            }
            else
            {
                if (operation == null)
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

        public void Default()
        {
            result = null;
            operation = null;
            operands[0] = null;
            operands[1] = null;
        }
    }
}
