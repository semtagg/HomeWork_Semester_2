using System;

namespace HW_4_Task_1
{
    /// <summary>
    /// Data structure used to store the arithmetic tree.
    /// </summary>
    public class Tree
    {
        private INode root;

        /// <summary>
        /// Builds an arithmetic tree.
        /// </summary>
        public void Build(string expression)
        {
            var cursor = 0;
            root = BuildNode(expression.Split(' ', StringSplitOptions.RemoveEmptyEntries), ref cursor);
        }

        private INode BuildNode(string[] expression, ref int cursor)
        {

            while (!IsOperator(expression[cursor]))
            {
                if (int.TryParse(expression[cursor], out int value))
                {
                    cursor++;
                    return new Operand(value);
                }
                if (!IsCorrectElement(expression[cursor]))
                {
                    throw new IncorrectFormOfExpressionException();
                }
                cursor++;
            }

            if (IsOperator(expression[cursor]))
            {
                cursor++;
                return expression[cursor - 1] switch
                {
                    "+" => new Addition(BuildNode(expression, ref cursor), BuildNode(expression, ref cursor)),
                    "-" => new Subtraction(BuildNode(expression, ref cursor), BuildNode(expression, ref cursor)),
                    "/" => new Division(BuildNode(expression, ref cursor), BuildNode(expression, ref cursor)),
                    "*" => new Multiplication(BuildNode(expression, ref cursor), BuildNode(expression, ref cursor)),
                    _ => throw new IncorrectFormOfExpressionException(),
                };
            }
            return null;
        }

        private bool IsCorrectElement(string element)
            => (element == "(") || (element == ")");

        private bool IsOperator(string element)
            => (element == "+") || (element == "-") || (element == "*") || (element == "/");

        /// <summary>
        /// Calculates the result of the expression.
        /// </summary>
        /// <returns>Result.</returns>
        public double Calculate()
            => root.Calculate();

        /// <summary>
        /// Prints the expression.
        /// </summary>
        public void Print()
            => root.Print();
    }
}
