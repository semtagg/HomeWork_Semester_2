using System;
using System.Collections.Generic;
using System.Text;

namespace HW_6_Task_1
{
    static class Methods<T>
    {
        public static List<T> Map(List<T> list, Func<T, T> func)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                newList.Add(func(element));
            }
            return newList;
        }

        public static List<T> Filter(List<T> list, Func<T, bool> func)
        {
            var newList = new List<T>();
            foreach (var element in list)
            {
                if (func(element))
                {
                    newList.Add(element);
                }      
            }
            return newList;
        }

        public static T Fold(List<T> list, T value, Func<T, T, T> func)
        {
            foreach (var element in list)
            {
                value = func(value, element);
            }
            return value;
        }
    }
}
