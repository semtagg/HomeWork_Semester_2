using System;

namespace HW_4_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            var expression = "( * ( + 1 ( - 5 3 ) ( / 4 2 )";
            try
            {
                tree.Build(expression);
            }
            catch (IncorrectFormOfExpressionException)
            {
                Console.WriteLine("Incorrect form of the expression.");
                return;
            }
            Console.WriteLine($"Result: {tree.Calculate()}");
            tree.Print();
        }
    }
}
