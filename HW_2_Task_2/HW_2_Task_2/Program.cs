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
            var inputLine = Console.ReadLine();
            var secondCalcElement = new Calculator(new ListStack());
            var firstCalcElement = new Calculator(new ArrayStack());
            Console.WriteLine($"Результат стекового калькулятора на основе списка: {secondCalcElement.GetResult(inputLine)}.");
            Console.WriteLine($"\nРезультат стекового калькулятора на основе массива: {firstCalcElement.GetResult(inputLine)}.");
            Console.WriteLine("\nОни же равны?..");
        }
    }
}