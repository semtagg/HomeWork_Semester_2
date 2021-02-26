using System;
namespace HW_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var result = new LzwAlgorithm();
            result.Decompress("a");
            var trie = new Trie();
            trie.Add("привет");
            trie.Add("мир");
            trie.Add("приз");
            trie.Add("мирный");
            trie.Add("подарок");
            trie.Add("проект");
            trie.Add("прапорщик");
            trie.Add("правый");
            trie.Add("год");
            trie.Add("герой");
            trie.Add("голубь");
            trie.Add("прокрастинация");
            trie.Add("красота");*/
/*
            trie.Remove("правый");
            trie.Remove("мир");

            byte value;

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
            }*/

            var s = new LzwAlgorithm();
            s.Compress("text.txt");
            Console.WriteLine("");
        }
    }
}
