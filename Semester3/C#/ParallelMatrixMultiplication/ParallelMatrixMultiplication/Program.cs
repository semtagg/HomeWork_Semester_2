using System;

namespace ParallelMatrixMultiplication
{
    static class Program
    {
        static void Main(string[] args)
        {
            /*var m1 = FileManager.ReadFromFile("matrix1.txt");
            var m2 = FileManager.ReadFromFile("matrix2.txt");*/
            var m1 = new int[1000, 1000];
            var m2 = new int[1000, 1000];
            
            for (var i = 0; i < 1000; i++)
                for (var j = 0; j < 1000; j++)
                {
                    m1[i, j] = new Random().Next() % 100;
                    m2[i, j] = new Random().Next() % 100;
                }
                
            
            
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            var r = MatrixManager.MatrixMultiplication(m1, m2);
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //FileManager.WriteToFile(r, "r.txt");
        }
    }
}
