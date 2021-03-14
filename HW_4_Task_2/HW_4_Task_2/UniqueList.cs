namespace HW_4_Task_2
{
    /// <summary>
    /// List that contains only unique elements.
    /// </summary>
    public class UniqueList : List
    {
        public override void InsertByIndex(int value, int index)
        {
            if (CheckValue(value))
            {
                throw new AddElementException("Element is already there.");
            }
            else
            {
                base.InsertByIndex(value, index);
            }
        }
    }
}
