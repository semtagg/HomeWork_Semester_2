using System;

namespace HW_3_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BTree(2);
            tree.Insert("1", "1");
            tree.Insert("2", "2");
            tree.Insert("3", "3");
            tree.Insert("4", "4");
            tree.Insert("22", "5");
            tree.Insert("30", "6");
            tree.Insert("31", "7");
            tree.Insert("32", "8");
            tree.Insert("3", "9");
            tree.Insert("4", "10");
            tree.Insert("5", "11");
            tree.Insert("6", "12");
            tree.Insert("7", "13");
            tree.Insert("8", "14");
            tree.Insert("23", "15");
            tree.Insert("24", "16");
            tree.Insert("25", "17");
            tree.Insert("26", "18");
            tree.Insert("28", "19");
            tree.Insert("27", "20");

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
            Console.WriteLine(tree.GetValue("27"));

        }
    }
}