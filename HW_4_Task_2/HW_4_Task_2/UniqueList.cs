using System;
using System.Collections.Generic;
using System.Text;

namespace HW_4_Task_2
{
    class UniqueList : List
    {
        public override void InsertByIndex(int index, int value)
        {
            if (!IndexCheck(index))
            {
                throw new IndexOutOfRangeException();
            }
            if (SearchByValue(value) == null)
            {
                // кинуть ошибку из созданного класса
            }
            else
            {
                base.InsertByIndex(index, value);
            }
        }
    }
}
