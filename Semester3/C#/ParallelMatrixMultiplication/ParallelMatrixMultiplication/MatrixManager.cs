using System.Collections.Generic;
using System.Threading;

namespace ParallelMatrixMultiplication
{
    public static class MatrixManager
    {
        public static int[,] MatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
        {
            // size
            var result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            var threads = new List<Thread>();
            for (var i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < secondMatrix.GetLength(1); j++)
                {
                    var columnIndex = i;
                    var rowIndex = j;
                    var thread = new Thread(() =>
                    {
                        for (var k = 0; k < firstMatrix.GetLength(0); k++)
                        {
                            result[columnIndex, rowIndex] += firstMatrix[columnIndex, k] * secondMatrix[k, rowIndex];
                        }});
                    thread.Start();
                    threads.Add(thread);
                }
            }
            foreach (var t in threads)
                t.Join();
            return result;
        }
    }
}
