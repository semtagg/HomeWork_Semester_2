using System;
using System.IO;

namespace HW_5_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2 || !File.Exists(args[0]) || File.Exists(args[1]))
            {
                Console.WriteLine("Error. Try again!");
            }
            try
            {
                FilesManager.GetOptimalNetwork(args[0], args[1]);
            }
            catch (GraphIsNotConnectedException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
