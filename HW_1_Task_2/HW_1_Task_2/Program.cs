using System;
namespace HW_1_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Tests.Test())
            {
                Console.WriteLine("The test was failled.");
                return;
            }
            else
            {
                Console.WriteLine("The test was passed.");
            }
            Console.WriteLine("Входные данные: ");
            char specialSymbol = '$';
            var inputLine = Console.ReadLine() + specialSymbol;
            var outputLine = BWT.Inverse(inputLine);
            var result = BWT.Reverse(outputLine);
            Console.WriteLine(outputLine+"\t"+ outputLine.Length);
            
            Console.WriteLine(result);
            if (String.Equals(result + specialSymbol, inputLine))
            {
                Console.WriteLine("All right. Good job!");
            }
            else
            {
                
                Console.WriteLine("Oops... Error!\n");
            }
        }
    }
}