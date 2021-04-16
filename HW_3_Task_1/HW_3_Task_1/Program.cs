using System;

namespace HW_3_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree(2);
            tree.Insert("1", "0");
            tree.Insert("2", "0");
            tree.Insert("3", "0");
            tree.Insert("4", "0");
            tree.Insert("5", "0");
            tree.Insert("6", "0");
            tree.Insert("7", "0");
            tree.Insert("8", "0");
            tree.Insert("9", "0");

            tree.Remove("2");
            tree.Remove("5");
            tree.Remove("2");
            tree.Remove("3");
            tree.Remove("4");
           /* tree.Insert("1", "0");
            tree.Insert("2", "0");
            tree.Insert("20", "0");
            tree.Insert("21", "0");
            tree.Insert("22", "0");

            tree.Insert("30", "0");
            tree.Insert("31", "0");
            tree.Insert("32", "0");

            tree.Insert("3", "0");
            tree.Insert("4", "0");
            tree.Insert("5", "0");

            tree.Insert("6", "0");
            tree.Insert("7", "0");
            tree.Insert("8", "6");

            tree.Insert("23", "3");
            tree.Insert("24", "0");
            tree.Insert("25", "0");
            tree.Insert("26", "0");
            tree.Insert("28", "0");
            tree.Insert("27", "1");

            tree.CheckKey("32");

            Console.WriteLine(tree.CheckKey("1"));
            Console.WriteLine(tree.CheckKey("2"));
            Console.WriteLine(tree.CheckKey("20"));
            Console.WriteLine(tree.CheckKey("21"));
            Console.WriteLine(tree.CheckKey("22"));
            Console.WriteLine(tree.CheckKey("30"));
            Console.WriteLine(tree.CheckKey("31"));
            Console.WriteLine(tree.CheckKey("3"));
            Console.WriteLine(tree.CheckKey("4"));
            Console.WriteLine(tree.CheckKey("5"));
            Console.WriteLine(tree.CheckKey("6"));
            Console.WriteLine(tree.CheckKey("7"));
            Console.WriteLine(tree.CheckKey("8"));
            Console.WriteLine(tree.CheckKey("23"));
            Console.WriteLine(tree.CheckKey("24"));
            Console.WriteLine(tree.CheckKey("25"));
            Console.WriteLine(tree.CheckKey("26"));
            Console.WriteLine(tree.CheckKey("28"));
            Console.WriteLine(tree.CheckKey("27"));

            Console.WriteLine(tree.GetValue("1"));
            Console.WriteLine(tree.GetValue("2"));
            Console.WriteLine(tree.GetValue("20"));
            Console.WriteLine(tree.GetValue("21"));
            Console.WriteLine(tree.GetValue("22"));
            Console.WriteLine(tree.GetValue("30"));
            Console.WriteLine(tree.GetValue("31"));
            Console.WriteLine(tree.GetValue("3"));
            Console.WriteLine(tree.GetValue("4"));
            Console.WriteLine(tree.GetValue("5"));
            Console.WriteLine(tree.GetValue("6"));
            Console.WriteLine(tree.GetValue("7"));
            Console.WriteLine(tree.GetValue("8"));
            Console.WriteLine(tree.GetValue("23"));
            Console.WriteLine(tree.GetValue("24"));
            Console.WriteLine(tree.GetValue("25"));
            Console.WriteLine(tree.GetValue("26"));
            Console.WriteLine(tree.GetValue("28"));
            Console.WriteLine(tree.GetValue("27"));*/

        }
    }
}