using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    /// <summary>
    /// Exception related to adding of items.
    /// </summary>
    [Serializable]
    public class AddElementException : Exception
    {
        public AddElementException() 
        {
        }

        public AddElementException(string message) 
            : base (message) 
        {
        }

        public AddElementException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected AddElementException(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }
    }
}
