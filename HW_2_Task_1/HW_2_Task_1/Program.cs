using System;

namespace HW_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie<int>();
            trie.Add("привет", 50);
            trie.Add("мир", 100);
            trie.Add("приз", 50);
            trie.Add("мирный", 50);
            trie.Add("подарок", 100);
            trie.Add("проект", 50);
            trie.Add("прапорщик", 50);
            trie.Add("правый", 100);
            trie.Add("год", 50);
            trie.Add("герой", 50);
            trie.Add("голубь", 100);
            trie.Add("прокрастинация", 1000);
            trie.Add("красота", 300);

            trie.Remove("правый");
            trie.Remove("мир");

            int value;

            if (trie.Search("привет", out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Not find!");
            }
            if (trie.Search("мир", out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Not find!");
            }
            if (trie.Search("облако", out value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Not find!");
            }
            var t = 1D;
        }
    }
}
