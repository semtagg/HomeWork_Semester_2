using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HW_5_Task_2
{
    class FilesManager
    {
        //private string[] separatingStrings = { " ", ":", "(", ")", "." };
        static private int[,] ReadFromFile(string path)
        {
            string[] separatingStrings = { " ", ":", "(", ")", ".", "," };
            var data = File.ReadAllLines(path);
            var maxSize = data.Length + 1; // это беда или не очень
            var graph = new int[maxSize, maxSize];
            for (int i = 0; i < data.Length; i++)
            {
                var currentLine = data[i].Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);
                for(int j = 1; j < currentLine.Length; j+=2)
                {
                    graph[int.Parse(currentLine[0]) - 1, int.Parse(currentLine[j]) - 1] = int.Parse(currentLine[j+1]);
                    graph[int.Parse(currentLine[j]) - 1, int.Parse(currentLine[0]) - 1] = int.Parse(currentLine[j + 1]);
                }
            }
            return Algorithm.Prim(graph); // на несвязность нужно что-то
        }

        static public void WriteToFile(string path)
        {
            var graph = ReadFromFile(path);
            using var writeFile = new StreamWriter("Result"+path, false, Encoding.Default);

            for (int i = 0; i < graph.GetUpperBound(0) + 1; i++)
            {
                string line = $"{i + 1}: ";
                for (int j = 0; j < graph.GetUpperBound(0) + 1; j++)
                {
                    
                    if (j == graph.GetUpperBound(0) && graph[i, j] != 0 && i != j && graph[i, j] != int.MaxValue)
                    {
                        line += $"{j + 1} ({graph[i, j]}).";
                        graph[i, j] = int.MaxValue;
                        graph[j, i] = int.MaxValue;
                    }
                    else if (graph[i, j] != 0 && i!=j && graph[i, j] != int.MaxValue)
                    {
                        line += $"{j + 1} ({graph[i, j]}), ";
                        graph[i, j] = int.MaxValue;
                        graph[j, i] = int.MaxValue;
                    }
                }
                if (line.Length != 3)
                {
                    writeFile.WriteLine(line);
                }
            }
        }
    }
}
