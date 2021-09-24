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
            
            Console.WriteLine($"Обычное вычисление.\n Мат. ожидание: {firstExpectation} ms. Среднеквадратичное отклонение: {firstVariance} ms.");
            Console.WriteLine($"Параллельное вычисление.\n Мат. ожидание: {secondExpectation} ms. Среднеквадратичное отклонение: {secondVariance} ms.");
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
            Test(100, 10);
            Test(500, 10);
            Test(1000, 10);
            Test(2000, 10);
        }
    }
}
/*
    Размер матрицы: 100. Количество экспериментов: 10.
    Обычное вычисление.
    Мат. ожидание: 11,1 ms. Среднеквадратичное отклонение: 1,2206555615733703 ms.
    Параллельное вычисление.
     Мат. ожидание: 3,2 ms. Среднеквадратичное отклонение: 0,39999999999999997 ms.
    **********************
    Размер матрицы: 500. Количество экспериментов: 10.
    Обычное вычисление.
    Мат. ожидание: 1299,3 ms. Среднеквадратичное отклонение: 78,1588766551823 ms.
    Параллельное вычисление.
    Мат. ожидание: 242,6 ms. Среднеквадратичное отклонение: 19,458674158328467 ms.
    **********************
    Размер матрицы: 1000. Количество экспериментов: 10.
    Обычное вычисление.
    Мат. ожидание: 12956,9 ms. Среднеквадратичное отклонение: 516,9577255443621 ms.
    Параллельное вычисление.
    Мат. ожидание: 1897,8 ms. Среднеквадратичное отклонение: 81,65512843661445 ms.
    **********************
 */
