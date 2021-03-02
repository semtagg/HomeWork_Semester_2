using System;
namespace HW_2_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new LzwAlgorithm();
            s.Compress("123.txt");
            Console.WriteLine("");

            /*s.Decompress("123.txt.zipped");*/
        }
    }
}
