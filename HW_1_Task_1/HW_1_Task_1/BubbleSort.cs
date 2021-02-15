namespace HW_1_Task_1
{
    class Sort
    {
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    { 
                        int swap = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = swap;
                    }
                }
            }
        }
    }
}
