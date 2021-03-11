using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    [Serializable]
    class DeleteElementError : Exception
    {
        public DeleteElementError()
        {
        }

        public DeleteElementError(string message)
            : base(message)
        {
        }

        public DeleteElementError(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DeleteElementError(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}