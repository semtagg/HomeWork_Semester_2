using System;
using System.IO;
using System.Text;

namespace HW_5_Task_2
{
    /// <summary>
    /// A class that contains methods for working with files and for finding optimal network by them.
    /// </summary>
    public static class FilesManager
    {
        private static string[] separatingStrings = { " ", ":", "(", ")", ".", "," };

        private static int[,] InitGraph(int size)
        {
            var graph = new int[size, size];
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    graph[i, j] = int.MinValue;
                }
            }
            return graph;
        }

        private static int GetMaxSize(string path)
        {
            var data = File.ReadAllLines(path);
            int maxSize = 1;
            for (int i = 0; i < data.Length; i++)
            {
                var currentLine = data[i].Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                if(int.Parse(currentLine[0]) > maxSize)
                {
                    maxSize = int.Parse(currentLine[0]);
                }
                for (int j = 1; j < currentLine.Length; j += 2)
                {
                    if (int.Parse(currentLine[j]) > maxSize)
                    {
                        maxSize = int.Parse(currentLine[j]);
                    }
                }
            }
            return maxSize;
        }

        private static int[,] ReadFromFile(string path)
        {
            var maxSize = GetMaxSize(path);
            var graph = InitGraph(maxSize);
            var data = File.ReadAllLines(path);
            for (int i = 0; i < data.Length; i++)
            {
                var currentLine = data[i].Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 1; j < currentLine.Length; j+=2)
                {
                    graph[int.Parse(currentLine[0]) - 1, int.Parse(currentLine[j]) - 1] = int.Parse(currentLine[j + 1]);
                    graph[int.Parse(currentLine[j]) - 1, int.Parse(currentLine[0]) - 1] = int.Parse(currentLine[j + 1]);
                }
            }
            try
            {
                return Algorithm.ChangedPrim(graph);
            }
            catch (GraphIsNotConnectedException)
            {
                throw new NetworkIsNotConnectedException();
            }
        }

        private static void WriteToFile(string inputPath, string outputPath)
        {
            var graph = ReadFromFile(inputPath);
            using var writeFile = new StreamWriter(outputPath, false, Encoding.Default);
            for (int i = 0; i < graph.GetUpperBound(0) + 1; i++)
            {
                string line = $"{i + 1}: ";
                for (int j = 0; j < graph.GetUpperBound(0) + 1; j++)
                {
                    if (graph[i,j] != int.MinValue)
                    {
                        line += $"{j + 1} ({graph[i, j]}), ";
                        graph[i, j] = int.MinValue;
                        graph[j, i] = int.MinValue;
                    }
                }
                if (line.Length != 3)
                {
                    writeFile.WriteLine(line[..(line.Length - 2)]);
                }
            }
        }

        /// <summary>
        /// Method that finds the optimal network.
        /// </summary>
        /// <param name="inputPath">The path to the input file.</param>
        /// <param name="outputPath">The path to the output file.</param>
        public static void GetOptimalNetwork(string inputPath, string outputPath)
        {
            WriteToFile(inputPath, outputPath);
        }
    }
}
