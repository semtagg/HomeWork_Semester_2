using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParallelMatrixMultiplication
{
    /// <summary>
    /// A class containing methods that read from and write to files.
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Reads 2D array from file.
        /// </summary>
        public static int[,] ReadMatrixFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();               
            }
            
            return File.ReadAllLines(path)
                .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                .ToArray()
                .ToRectangularArray();
        }

        /// <summary>
        /// Writes 2D array to file.
        /// </summary>
        public static void WriteMatrixToFile(int[,] matrix, string fileName)
        {
            using TextWriter textWriter = new StreamWriter(fileName);
            for (var j = 0; j < matrix.GetLength(0); j++)
            {
                for (var i = 0; i < matrix.GetLength(1); i++)
                {
                    if (i != 0)
                    {
                        textWriter.Write(" ");
                    }
                    textWriter.Write(matrix[j, i]);
                }
                textWriter.WriteLine();
            }
        }
        
        private static T[,] ToRectangularArray<T>(this IReadOnlyList<T[]> arrays)
        {
            var result = new T[arrays.Count, arrays[0].Length];
            
            for (var i = 0; i < arrays.Count; i++)
            {
                for (var j = 0; j < arrays[0].Length; j++)
                {
                    result[i, j] = arrays[i][j];
                }
            }
                
            return result;
        }
    }
}
