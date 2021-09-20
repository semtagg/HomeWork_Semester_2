using System;

namespace ParallelMatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var expectedMatrix = new int[2, 2]
            {
                {1, 2},
                {3, 4}
            };
            
            FileManager.WriteMatrixToFile(expectedMatrix, "hello.txt");
            var matrix = FileManager.ReadMatrixFromFile("..\\..\\..\\hello.txt");
        }
    }
}
