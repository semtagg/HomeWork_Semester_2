namespace HW_4_Task_2
{
    /// <summary>
    /// List that contains only unique elements.
    /// </summary>
    public class UniqueList : List
    {
        public override void Insert(int value, int index)
        {
            if (CheckValue(value))
            {
                throw new ElementIsAlreadyExistException();
            }
            base.Insert(value, index);
        }

        public override void Change(int value, int index)
        {
            var indexFlag = SearchByValue(value); 
            if (indexFlag != index && indexFlag != -1)
            {
                throw new ElementIsAlreadyExistException();
            }
            base.Change(value, index);
        }
    }
}
