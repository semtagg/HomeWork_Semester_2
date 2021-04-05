using System;
using System.IO;

namespace HW_5_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FilesManager.GetOptimalNetwork(args[0], args[1]);
            }
            catch (NetworkIsNotConnectedException ex)
            {
                var errorWriter = Console.Error;
                errorWriter.WriteLine(ex.Message);
                return;
            }
        }
    }
}
