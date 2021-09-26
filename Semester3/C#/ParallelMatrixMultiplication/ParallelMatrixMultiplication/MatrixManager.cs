using System;
using System.Threading;

namespace ParallelMatrixMultiplication
{
    /// <summary>
    /// A class containing methods that multiply matrices (in parallel and ordinary).
    /// </summary>
    public static class MatrixManager
    {
        /// <summary>
        /// Performs matrix multiplication, returns multiplication result or error.
        /// </summary>
        public static int[,] ParallelMatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new InvalidMatrixSizeException();
            }

            var result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            var threadsCount = Environment.ProcessorCount;
            var threads = new Thread[threadsCount];
            var iterationsCount = firstMatrix.GetLength(0) / threadsCount;
            
            for (var index = 0; index < threadsCount; index++)
            {
                var startPoint = index * iterationsCount;
                var endPoint = index == threadsCount - 1 && firstMatrix.GetLength(0) % threadsCount != 0
                    ? firstMatrix.GetLength(0)
                    : (index + 1) * iterationsCount;
                
                threads[index] = new Thread(() =>
                {
                    for (var i = startPoint; i < endPoint; i++)
                    {
                        for (var j = 0; j < secondMatrix.GetLength(1); j++)
                        {
                            for (var k = 0; k < firstMatrix.GetLength(0); k++)
                            {
                                result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                            }
                        }
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            
            return result;
        }
        
        public static int[,] RandomMatrix(int rowNumber, int columnNumber)
        {
            var matrix = new int[rowNumber, columnNumber];
            for (var i = 0; i < rowNumber; i++)
            {
                for (var j = 0; j < columnNumber; j++)
                {
                    matrix[i, j] = new Random().Next() % 1000;
                }    
            }

            return matrix;
        }

        public static int[,] OrdinaryMatrixMultiplication(int[,] m1, int[,] m2)
        {
            var result = new int[m1.GetLength(0), m2.GetLength(1)];
            for (var i = 0; i < m1.GetLength(0); i++)
            {
                for (var j = 0; j < m2.GetLength(1); j++)
                {
                    for (var k = 0; k < m2.GetLength(0); k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return result;
        }
    }
}
