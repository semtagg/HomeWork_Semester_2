using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;

namespace ParallelMatrixMultiplication
{
    class Program
    {
        private static void VarianceAndExpectation(List<double> firstWatch, List<double> secondWatch)
        {
            var firstExpectation = firstWatch.Average();
            var secondExpectation = secondWatch.Average();

            var firstVariance = Math.Sqrt(firstWatch.Select(t => Math.Pow(t - firstExpectation, 2)).Average());
            var secondVariance = Math.Sqrt(secondWatch.Select(t => Math.Pow(t - secondExpectation, 2)).Average());
            
            Console.WriteLine($"Обычное вычисление.\n Мат. ожидание: {firstExpectation} ms. Среднеквадратичное значение: {firstVariance} ms.");
            Console.WriteLine($"Параллельное вычисление.\n Мат. ожидание: {secondExpectation} ms. Среднеквадратичное значение: {secondVariance} ms.");
            Console.WriteLine("**********************");
        }
        
        private static void Test(int matrixSize, int number)
        {
            Console.WriteLine($"Размер матрицы: {matrixSize}. Количество экспериментов: {number}.");
            
            var firstWatch = new List<double>();
            var secondWatch = new List<double>();
            var watch = new Stopwatch();
            for (var i = 0; i < number; i++)
            {
                var firstRandomMatrix = MatrixManager.RandomMatrix(matrixSize, matrixSize);
                var secondRandomMatrix = MatrixManager.RandomMatrix(matrixSize, matrixSize);
                
                watch.Start();
                MatrixManager.OrdinaryMatrixMultiplication(firstRandomMatrix, secondRandomMatrix);
                watch.Stop();
                firstWatch.Add(watch.ElapsedMilliseconds);
                
                watch.Restart();
                MatrixManager.ParallelMatrixMultiplication(firstRandomMatrix, secondRandomMatrix);
                watch.Stop();
                secondWatch.Add(watch.ElapsedMilliseconds);
            }
            
            VarianceAndExpectation(firstWatch, secondWatch);
        }
        
        static void Main(string[] args)
        {
            Test(10, 100);
            Test(100, 10);
            Test(1000, 10);
        }
    }
}
/*
    Размер матрицы: 10. Количество экспериментов: 100.
    Обычное вычисление.
    Мат. ожидание: 0,13 ms. Среднеквадратичное значение: 0,36482872693909363 ms.
    Параллельное вычисление.
    Мат. ожидание: 0,12 ms. Среднеквадратичное значение: 0,3544009029333872 ms.
    **********************

    Размер матрицы: 100. Количество экспериментов: 10.
    Обычное вычисление.
    Мат. ожидание: 15,9 ms. Среднеквадратичное значение: 2,981610303175114 ms.
    Параллельное вычисление.
    Мат. ожидание: 9,1 ms. Среднеквадратичное значение: 0,29999999999999993 ms.
    **********************
    
    Размер матрицы: 1000. Количество экспериментов: 10.
    Обычное вычисление.
    Мат. ожидание: 12640 ms. Среднеквадратичное значение: 571,2489824936234 ms.
    Параллельное вычисление.
    Мат. ожидание: 1961,8 ms. Среднеквадратичное значение: 26,727513913568544 ms.
    **********************
 */
