using System;

namespace ParallelMatrixMultiplication
{
    static class Program
    {
        static void Main(string[] args)
        {
            var m1 = FileManager.ReadFromFile("matrix1.txt");
            var m2 = FileManager.ReadFromFile("matrix2.txt");
            var r = MatrixManager.MatrixMultiplication(m1, m2);
            FileManager.WriteToFile(r, "r.txt");
        }
    }
}
