using System;
using System.Threading;

namespace ParallelMatrixMultiplication
{
    public static class MatrixManager
    {
        /// <summary>
        /// Performs matrix multiplication, returns multiplication result or error.
        /// </summary>
        public static int[,] ParallelMatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
                throw new InvalidMatrixSizeException();
            
            var result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            var threads = new Thread[firstMatrix.GetLength(0)];
            
            for (var i = 0; i < firstMatrix.GetLength(0); i++)
            {
                var columnIndex = i;
                threads[i] = new Thread(() =>
                {
                    for (var j = 0; j < secondMatrix.GetLength(1); j++)
                    {
                        for (var k = 0; k < firstMatrix.GetLength(0); k++)
                        {
                            result[columnIndex, j] += firstMatrix[columnIndex, k] * secondMatrix[k, j];
                        }
                    }
                });
            }
            
            foreach (var t in threads)
                t.Start();
            foreach (var t in threads)
                t.Join();
            
            return result;
        }
        
        public static int[,] RandomMatrix(int rowNumber, int columnNumber)
        {
            var matrix = new int[rowNumber, columnNumber];
            for (var i = 0; i < rowNumber; i++)
            {
                for (var j = 0; j < columnNumber; j++)
                {
                    matrix[i, j] = new Random().Next() % 100;
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
                        result[i,j] += m1[i,k] * m2[k,j];
                    }
                }
            }

            return result;
        }
    }
}
