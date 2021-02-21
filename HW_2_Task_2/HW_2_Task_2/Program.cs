using System;

namespace HW_2_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Test.Tests())
            {
                Console.WriteLine("Tests were passed!");
            }
            else
            {
                Console.WriteLine("Tests weren't passed!");
                return;
            }
            Console.WriteLine("Введите строку в постфиксной записи: ");
            var inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var listCalcElement = new Calculator(new ListCalc());
            var arrayCalcElement = new Calculator(new ArrayCalc());
            Console.WriteLine($"Резултат стекового калькулятора на основе списка: {listCalcElement.GetResult(inputLine)}.");
            Console.WriteLine($"\nРезултат стекового калькулятора на основе массива: { arrayCalcElement.GetResult(inputLine)}.");
            Console.WriteLine("\nОни же равны?..");
        }
    }
}
