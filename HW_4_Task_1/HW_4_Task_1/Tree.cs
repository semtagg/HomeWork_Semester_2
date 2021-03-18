namespace HW_4_Task_1
{
    /// <summary>
    /// Data structure used to store the arithmetic tree.
    /// </summary>
    public class Tree
    {
        private INode root;
        private int cursor;

        /// <summary>
        /// Builds an arithmetic tree.
        /// </summary>
        public void Build(string[] expression)
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
