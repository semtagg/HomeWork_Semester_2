using System;

namespace HW_5_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
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