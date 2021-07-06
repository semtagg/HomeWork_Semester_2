using System;
using System.Collections.Generic;

namespace HW_6_Task_1
{
    public class Methods
    {
        /// <summary>
        /// Applies the passed function to each item in the passed list.
        /// </summary>
        public static List<TOut> Map<TIn, TOut>(List<TIn> list, Func<TIn, TOut> func)
        {
            var newList = new List<TOut>();
            foreach (var element in list)
            {
                newList.Add(func(element));
            }
            return newList;
        }

        /// <summary>
        /// Leaves the elements of the passed list for which the passed function returned true.
        /// </summary>
        public static List<T> Filter<T>(List<T> list, Func<T, bool> func)
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

        /// <summary>
        /// Accumulates the value of all elements in the list.
        /// </summary>
        public static TOut Fold<TIn, TOut>(List<TIn> list, TOut value, Func<TOut, TIn, TOut> func)
        {
            foreach (var element in list)
            {
                value = func(value, element);
            }
            return value;
        }
    }
}
