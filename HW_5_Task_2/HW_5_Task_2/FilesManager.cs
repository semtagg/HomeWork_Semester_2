using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW_5_Task_2
{
    class FilesManager
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

        private static bool CheckGraph(int[,] graph)
        {
            var size = graph.GetUpperBound(0) + 1;
            var vertices = new int[size];
            var flag = false;
            int index = 0;
            vertices[0] = 1;
            while (!flag)
            {
                flag = true;
                for (int i = 0; i < size; i++)
                {
                    if(vertices[i] == 1)
                    {
                        vertices[i] = 2;
                        index = i;
                        break;
                    }
                }
                for (int j = 0; j < size; j++)
                {
                    if (graph[index, j] != int.MinValue && vertices[j] == 0)
                    {
                        vertices[j] = 1;
                    }
                }
                for (int k = 0; k < size; k++)
                {
                    if (vertices[k] == 1)
                    {
                        flag = false;
                    }
                }
            }
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                if (vertices[i] == 0)
                {
                    result++;
                }
            }
            return result == 0 ? true : false;
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
            if(!CheckGraph(graph))
            {
                throw new NetworkIsNotConnectedException();
            }
            return Algorithm.Prim(graph);
        }

        public static void WriteToFile(string inputPath, string outputPath)
        {
            var graph = ReadFromFile(inputPath);
            using var writeFile = new StreamWriter(outputPath, false, Encoding.Default);

            for (int i = 0; i < graph.GetUpperBound(0) + 1; i++)
            {
                string line = $"{i + 1}: ";
                for (int j = 0; j < graph.GetUpperBound(0) + 1; j++)
                {
                    
                    if (graph[i, j] != 0 && i!=j && graph[i, j] != int.MaxValue)
                    {
                        line += $"{j + 1} ({graph[i, j]}), ";
                        graph[i, j] = int.MaxValue;
                        graph[j, i] = int.MaxValue;
                    }
                }
                if (line.Length != 3)
                {
                    writeFile.WriteLine(line[..(line.Length - 2)]);
                }
            }
        }
    }
}
