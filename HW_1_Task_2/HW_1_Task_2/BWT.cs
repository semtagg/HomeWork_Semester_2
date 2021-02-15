using System;
using System.Linq;

namespace HW_1_Task_2
{
    class BWT
    {
        private static void BuildSuffixesArray(string[] newArray, string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                newArray[i] = line[i..^0];
            }
        }

        private static string BuildOutputLine(string[] arrayOfSuffixes, string inputLine)
        {
            var outputLine = "";
            for (int i = 0; i < inputLine.Length; i++)
            {
                outputLine += inputLine[(2 * inputLine.Length - (arrayOfSuffixes[i].Length + 1)) % inputLine.Length];
            }
            return outputLine;
        }

        public static string Inverse(string inputLine)
        {
            var arrayOfSuffixes = new string[inputLine.Length];
            BuildSuffixesArray(arrayOfSuffixes, inputLine);
            Array.Sort(arrayOfSuffixes);
            return (BuildOutputLine(arrayOfSuffixes, inputLine));
        }

        private static void BuildArrayOfPositions(int[] arrayOfPositions, char[] alphabetElements, string outputLine)
        {
            int countOfElements = 0;
            for (int i = 0; i < alphabetElements.Length; i++)
            {
                if (i >= 1)
                {
                    arrayOfPositions[i] += arrayOfPositions[i - 1] + countOfElements;
                }
                countOfElements = outputLine.Where(x => x == alphabetElements[i]).Count();
            }
        }

        private static void BuildWayOfReverse(int[] wayOfReverse, int[] arrayOfPositions, char[] alphabetElements, string outputLine)
        {
            for (int i = 0; i < outputLine.Length; i++)
            {
                 wayOfReverse[i] += arrayOfPositions[Array.IndexOf(alphabetElements, outputLine[i])] + 1;
                 arrayOfPositions[Array.IndexOf(alphabetElements, outputLine[i])]++;
            }
        }
        private static string GetInputLine(int[] wayOfReverse, int[] arrayOfPositions, string outputLine, int key)
        {            
            var inputLine = "";
            for (int i = 0; i < wayOfReverse.Length - 1; i++)
            {
                inputLine += outputLine[key - 1];
                key = wayOfReverse[key - 1];
            }
            return inputLine;
        }

        public static string Reverse(string outputLine)
        {
            var alphabetElements = string.Concat(outputLine.Select(s => $"{s}").Distinct()).ToCharArray();
            Array.Sort(alphabetElements);
            var arrayOfPositions = new int[alphabetElements.Length];
            BuildArrayOfPositions(arrayOfPositions, alphabetElements, outputLine);
            var wayOfReverse = new int[outputLine.Length];
            BuildWayOfReverse(wayOfReverse, arrayOfPositions, alphabetElements, outputLine);
            var key = arrayOfPositions[Array.IndexOf(alphabetElements, '$')];            
            return new string(GetInputLine(wayOfReverse, arrayOfPositions, outputLine, key).Reverse().ToArray());
        }
    }
}