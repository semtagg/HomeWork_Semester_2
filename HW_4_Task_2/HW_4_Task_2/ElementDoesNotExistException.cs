using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    /// <summary>
    /// Exception related to the deletion of non-existent items.
    /// </summary>
    [Serializable]
    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException()
        {
        }

        public ElementDoesNotExistException(string message)
            : base(message)
        {
        }

        public ElementDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ElementDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}