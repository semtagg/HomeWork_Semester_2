using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Task_1
{
    public class Tree
    {
        private INode root;
        private int cursor;
        public void BuildTree(string[] expression)
        {
            root = BuildNode(expression, ref cursor);
        }

        private INode BuildNode(string[] expression, ref int cursor)
        {
            
            while (!IsOperator(expression[cursor]))
            {   
                int value;
            
                if (int.TryParse(expression[cursor], out value))
                {
                    cursor++;
                    return new Operand(value);
                }
                if (!IsCorrectElement(expression[cursor]))
                {
                    throw new CorrectExpressionException();
                }
                cursor++;
            }
            
            if (IsOperator(expression[cursor]))
            {
                cursor++;
                return new Operator(expression[cursor - 1], BuildNode(expression, ref cursor), BuildNode(expression, ref cursor));
            }
            else
            {
                return null;
            }
        }

        private bool IsCorrectElement(string element)
            => (element == "(") || (element == ")") ? true : false;

        private bool IsOperator(string element)
            => (element == "+") || (element == "-") || (element == "*") || (element == "/") ? true : false;

        public double Calculate()
            => root.Calculate();

        public void Print()
            => root.Print();
    }
}
