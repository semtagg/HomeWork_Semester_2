using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    /// <summary>
    /// Exception related to the deletion of items.
    /// </summary>
    [Serializable]
    public class DeleteElementException : Exception
    {
        public DeleteElementException()
        {
        }

        public DeleteElementException(string message)
            : base(message)
        {
        }

        public DeleteElementException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DeleteElementException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}