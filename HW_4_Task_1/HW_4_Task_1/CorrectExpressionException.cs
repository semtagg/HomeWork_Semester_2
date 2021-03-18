using System;
using System.Runtime.Serialization;

namespace HW_4_Task_1
{
    [Serializable]
    public class CorrectExpressionException : Exception
    {
        public CorrectExpressionException()
        {
        }

        public CorrectExpressionException(string message)
            : base(message)
        {
        }

        public CorrectExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CorrectExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
