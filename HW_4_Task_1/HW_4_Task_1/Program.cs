using System;

namespace HW_4_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            var expression = "( * ( + 1 ( - 5 3 ) ( / 4 2 )".Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                tree.Build(expression);
            }
            catch (CorrectExpressionException)
            {
                throw new CorrectExpressionException("Incorrect form of the expression.");
            }
            Console.WriteLine($"Result: {tree.Calculate()}");
            tree.Print();
        }
    }
}
