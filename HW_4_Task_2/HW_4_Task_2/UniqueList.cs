namespace HW_4_Task_2
{
    class UniqueList : List
    {
        public override void InsertByIndex(int index, int value)
        {
            if (SearchByValue(value) != null)
            {
                throw new AddElementError("Element is already there.");
            }
            else
            {
                base.InsertByIndex(index, value);
            }
        }
    }
}
