using System;

namespace HW_4_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            var expression = "( * ( + 3 1 ) ( + 4 5 ) )";
            tree.BuildTree(expression.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(tree.Calculate());
            tree.Print();
        }
    }
}
