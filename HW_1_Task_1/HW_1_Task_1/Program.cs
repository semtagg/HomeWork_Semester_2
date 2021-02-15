using System;

namespace HW_1_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Test.Tests())
            {
                Console.WriteLine("Тест не пройден!");
                return;
            }
            else
            {
                Console.WriteLine("Тест пройден!");
            }
            Console.WriteLine("Введите размер массива: ");
            var arrayOfNumbers = new int[int.Parse(Console.ReadLine())];
            Console.WriteLine("Заполним массив рандомными числами и отсортируем.");
            var random = new Random();
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                arrayOfNumbers[i] = random.Next() % 100;   
            }
            Console.WriteLine("Результат: ");
            Sort.BubbleSort(arrayOfNumbers);
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                Console.WriteLine(arrayOfNumbers[i]);
            }
        }
    }
}
