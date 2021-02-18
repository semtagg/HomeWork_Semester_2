using System;
using System.Linq;

namespace HW_1_Task_2
{
    class BWT
    {
        public static void SpecialBubbleSort(int[] array, ref int[] secondArray, int begin, int end)
        {
            for (int i = begin; i <= end; i++)
            {
                for (int j = end; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int swap = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = swap;
                        swap = secondArray[j - 1];
                        secondArray[j - 1] = secondArray[j];
                        secondArray[j] = swap;
                    }
                }
            }
        }

        private static int[] GetCount(char[] alphabet, string inputLine)
        {
            var count = new int[alphabet.Length];
            for (int i = 0; i < alphabet.Length; i++)
            {
                count[i] = inputLine.Where(x => x == alphabet[i]).Count();
            }
            return count;
        }

        private static int[] GetArrayOfPositions(int[] count, char[] alphabet, string inputLine)
        {
            var positionsArray = new int[inputLine.Length];
            int index = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                int current = 0;
                for (int j = index; j < index + count[i]; j++)
                {
                    positionsArray[j] = inputLine.IndexOf(alphabet[i], current);
                    current = inputLine.IndexOf(alphabet[i], current) + 1;
                }
                index += count[i];
            }
            return positionsArray;
        }

        private static int[] GetArrayOfClasses(int[] count, char[] alphabet, string inputLine)
        {
            var classesArray = new int[inputLine.Length];
            int index = 0;
            int classes = 1;
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = index; j < index + count[i]; j++)
                {
                    classesArray[j] += classes;
                }
                classes++;
                index += count[i];
            }
            return classesArray;
        }

        private static void PerfomZeroIteration(string inputLine, out int[] positionsArray, out int[] classesArray)
        {
            var alphabet = string.Concat(inputLine.Select(s => $"{s}").Distinct()).ToCharArray();
            Array.Sort(alphabet);
            var countOfElements = GetCount(alphabet, inputLine);
            positionsArray = GetArrayOfPositions(countOfElements, alphabet, inputLine);
            classesArray = GetArrayOfClasses(countOfElements, alphabet, inputLine);
        }

        private static string GetSecondPartOfCurrentPreffix(string inputLine, int position, int currentLength)
        {
            string secondPartOfCurrentPreffix;
            if (position + currentLength > inputLine.Length)
            {
                secondPartOfCurrentPreffix = inputLine[position..];
                if (position + currentLength > 2 * inputLine.Length)
                {
                    if (currentLength - (inputLine.Length - position) > inputLine.Length)
                    {
                        secondPartOfCurrentPreffix += inputLine + inputLine[..(currentLength - (2 * inputLine.Length - position))];
                        return secondPartOfCurrentPreffix[(secondPartOfCurrentPreffix.Length / 2)..];
                    }
                }
                secondPartOfCurrentPreffix += inputLine[..(currentLength - (inputLine.Length - position))];
            }
            else
            {
                secondPartOfCurrentPreffix = inputLine[position..(position + currentLength)];
            }
            return secondPartOfCurrentPreffix[(secondPartOfCurrentPreffix.Length / 2)..];
        }

        private static string GetFirstPartOfCurrentPreffix(string inputLine, int position, int currentLength)
        {
            string firstPartOfCurrentPreffix;
            if (position + (currentLength / 2) <= inputLine.Length - 1)
            {
                firstPartOfCurrentPreffix = inputLine[position..(position + currentLength / 2)];
            }
            else
            {
                firstPartOfCurrentPreffix = inputLine[position..] + inputLine[..(currentLength / 2 - (inputLine.Length - position))];
            }
            return firstPartOfCurrentPreffix;
        }

        private static int[] GetHelpingArray(string inputLine, int[] positionsArray, int[] classesArray, int currentLength)
        {
            var helpArray = new int[inputLine.Length];
            for (int i = 0; i < inputLine.Length; i++)
            {
                for (int j = 0; j < inputLine.Length; j++)
                {
                    if ((GetSecondPartOfCurrentPreffix(inputLine, positionsArray[i], currentLength)) == (GetFirstPartOfCurrentPreffix(inputLine, positionsArray[j], currentLength)))
                    { 
                        helpArray[i] = classesArray[j];
                    }
                }
            }
            return helpArray;
        }

        private static void RebuildArrayOfPositions(int[] classesArray, ref int[] positionsArray, int[] helpArray)
        {
            for (int i = 0; i < classesArray.Length - 1; i++)
            {
                if (classesArray[i] < classesArray[i + 1])
                {
                    continue;
                }
                else if (classesArray[i] == classesArray[i + 1])
                {
                    int begin, end;
                    begin = end = i;
                    while ((i != (classesArray.Length - 1)) && (classesArray[i] == classesArray[i + 1]))
                    {
                        i++;
                    }
                    end = i;
                    SpecialBubbleSort(helpArray, ref positionsArray, begin, end);
                }
            }
        }

        private static void RebuildArrayOfClasses(ref int[] classesArray, int[] helpArray)
        {
            var array = new int[classesArray.Length];
            for (int i = 0; i < classesArray.Length; i++)
            {
                array[i] = classesArray[i];
            }
            classesArray[0] = 1;
            for (int i = 1; i < classesArray.Length; i++)
            {
                if ((array[i - 1] == array[i]) && (helpArray[i - 1] == helpArray[i]))
                {
                    classesArray[i] = classesArray[i - 1];
                }
                else
                {
                    classesArray[i] = classesArray[i - 1] + 1;
                }
            }
        }

        private static void PerfomRemainingIteration(string inputLine, ref int[] positionsArray, ref int[] classesArray)
        {
            int currentLength = 2;            
            while (currentLength <= (int)Math.Pow(2, Math.Ceiling(Math.Log2(inputLine.Length))))
            {
                var helpArray = GetHelpingArray(inputLine, positionsArray, classesArray, currentLength);
                RebuildArrayOfPositions(classesArray, ref positionsArray, helpArray);
                RebuildArrayOfClasses(ref classesArray, helpArray);
                currentLength += 2;
            }
        }

        private static string BuildAnswer(int[] array, string inputLine)
        {
            var answer = "";
            for (int i = 0; i < inputLine.Length; i++)
            {
                if (array[i] == 0)
                    answer += inputLine[inputLine.Length - 1];
                else
                    answer += inputLine[array[i] - 1];
            }
            return answer;
        }

        public static string Direct(string inputLine)
        {
            var positionsArray = new int[inputLine.Length];
            var classesArray = new int[inputLine.Length];
            PerfomZeroIteration(inputLine, out positionsArray, out classesArray);
            PerfomRemainingIteration(inputLine, ref positionsArray, ref classesArray);
            var outputLine = BuildAnswer(positionsArray, inputLine);
            return outputLine;
        }

        private static int[] BuildArrayOfPositions(char[] alphabetElements, string outputLine)
        {
            var arrayOfPositions = new int[alphabetElements.Length];
            int countOfElements = 0;
            for (int i = 0; i < alphabetElements.Length; i++)
            {
                if (i >= 1)
                {
                    arrayOfPositions[i] += arrayOfPositions[i - 1] + countOfElements;
                }
                countOfElements = outputLine.Where(x => x == alphabetElements[i]).Count();
            }
            return arrayOfPositions;
        }

        private static int[] BuildWayOfReverse(int[] arrayOfPositions, char[] alphabetElements, string outputLine)
        {
            var wayOfReverse = new int[outputLine.Length];
            for (int i = 0; i < outputLine.Length; i++)
            {
                 wayOfReverse[i] += arrayOfPositions[Array.IndexOf(alphabetElements, outputLine[i])] + 1;
                 arrayOfPositions[Array.IndexOf(alphabetElements, outputLine[i])]++;
            }
            return wayOfReverse;
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

        public static string Inverse(string outputLine)
        {
            var alphabetElements = string.Concat(outputLine.Select(s => $"{s}").Distinct()).ToCharArray();
            Array.Sort(alphabetElements);
            var arrayOfPositions = BuildArrayOfPositions(alphabetElements, outputLine);            
            var wayOfReverse = BuildWayOfReverse(arrayOfPositions, alphabetElements, outputLine);
            var key = arrayOfPositions[Array.IndexOf(alphabetElements, '$')];            
            return new string(GetInputLine(wayOfReverse, arrayOfPositions, outputLine, key).Reverse().ToArray());
        }
    }
}