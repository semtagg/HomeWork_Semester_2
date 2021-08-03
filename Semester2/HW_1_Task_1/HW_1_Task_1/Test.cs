namespace HW_1_Task_1
{
    class Test
    {
        private static bool Check(int[] firstArray, int[] secondArray)
        {
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Tests()
        {
            int[] firstArray = { 85, -86, 52 };
            int[] secondArray = { -86, 52, 85 };
            Sort.BubbleSort(firstArray);
            if (!Check(firstArray, secondArray))
            {
                return false;
            }
            int[] thirdArray = { -12, 45, -56, 23, -27 };
            int[] fourthArray = { -56, -27, -12, 23, 45 };
            Sort.BubbleSort(thirdArray);
            if (!Check(thirdArray, fourthArray))
            {
                return false;
            }
            int[] fifthArray = { -64, -61, 93, 15, 84, 69, 2 };
            int[] sixthArray = { -64, -61, 2, 15, 69, 84, 93 };
            Sort.BubbleSort(fifthArray);
            if (!Check(fifthArray, sixthArray))
            {
                return false;
            }
            return true;
        }
    }
}
