using System.Threading;

namespace ParallelMatrixMultiplication
{
    public static class MatrixManager
    {
        /// <summary>
        /// Performs matrix multiplication, returns multiplication result or error.
        /// </summary>
        public static int[,] MatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
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
    }
}
