using System;
using System.Linq;

namespace HW_1_Task_2
{
    class BWT
    {
        public static string Inverse(string inputLine)
        {
            var arrayOfSuffix = new string[inputLine.Length];
            for (int i = 0; i < inputLine.Length; i++)
            {
                arrayOfSuffix[i] = inputLine[i..^0];
            }
            Array.Sort(arrayOfSuffix);
            string outputLine = "";
            for (int i = 0; i < inputLine.Length; i++)
            {
                outputLine += inputLine[(2 * inputLine.Length - (arrayOfSuffix[i].Length + 1)) % inputLine.Length];
            }
            return (outputLine);
        }

        public static string Reverse(string outputLine)
        {
            var power = outputLine.Distinct().Count();
            var count = new int[power];
            var uniqueElements = string.Concat(outputLine.Select(s => $"{s}").Distinct()).ToCharArray();
            Array.Sort(uniqueElements);
            for (int i = 0; i < power; i++)
            {
                count[i] += outputLine.Where(x => x == uniqueElements[i]).Count();
            }
            var position = new int[power];
            for (int i = 1; i < power; i++)
            {
                position[i] += position[i - 1] + count[i - 1];
            }
            string value = String.Concat<char>(uniqueElements);
            var way = new int[outputLine.Length];
            for (int i = 0; i < outputLine.Length; i++)
            {
                way[i] += position[value.IndexOf(outputLine[i], 0, uniqueElements.Length)];
                position[value.IndexOf(outputLine[i], 0, uniqueElements.Length)]++;
            }
            string answer = "";
            int key = 0;
            for (int i = 0; i < outputLine.Length - 1; i++)
            {
                answer += outputLine[key];
                key = way[key];
            }
            return new string(answer.Reverse().ToArray());
        }
    }
}