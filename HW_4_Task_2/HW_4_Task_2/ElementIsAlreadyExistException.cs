using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    /// <summary>
    /// Exception related to adding existing items.
    /// </summary>
    [Serializable]
    public class ElementIsAlreadyExistException : Exception
    {
        public ElementIsAlreadyExistException() 
        {
        }

        public ElementIsAlreadyExistException(string message) 
            : base (message) 
        {
        }

        public ElementIsAlreadyExistException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ElementIsAlreadyExistException(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }
    }
}
