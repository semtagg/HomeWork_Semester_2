using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_2
{
    /// <summary>
    /// A class that contains an implementation of a queue with priorities.
    /// </summary>
    /// <typeparam name="T">Data type.</typeparam>
    public class PriorityQueue<T> where T : IComparable<T>
    {
        public PriorityQueue()
        {
            dictionary = new Dictionary<int, (int, T)>();
            index = 0;
        }

        private Dictionary<int, (int, T)> dictionary;
        private int index = 0;

        /// <summary>
        /// A method to add to the queue.
        /// </summary>
        /// <param name="value">Adding data.</param>
        /// <param name="priority">The priority of this data.</param>
        public void Enqueue(T value, int priority)
        {
            dictionary.Add(index, (priority, value));
            index++;
        }

        /// <summary>
        /// Method that returns data from the queue.
        /// </summary>
        /// <returns>Data with the highest priority.</returns>
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var result = dictionary.Values.First();
            var maxPriority = result.Item1;
            var currentKey = dictionary.Keys.First();

            foreach (var element in dictionary)
            {
                if (element.Value.Item1 > maxPriority)
                {
                    maxPriority = element.Value.Item1;
                    result = element.Value;
                    currentKey = element.Key;
                }
            }

            dictionary.Remove(currentKey);
            return result.Item2;
        }

        /// <summary>
        /// Method that checks if the queue is empty.
        /// </summary>
        public bool IsEmpty()
            => dictionary.Count == 0;
    }
}
