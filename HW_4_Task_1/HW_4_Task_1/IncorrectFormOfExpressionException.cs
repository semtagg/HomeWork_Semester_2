using System;
using System.Runtime.Serialization;

namespace HW_4_Task_1
{
    /// <summary>
    /// It is thrown if the form of expression is incorrect.
    /// </summary>
    [Serializable]
    public class IncorrectFormOfExpressionException : Exception
    {
        public IncorrectFormOfExpressionException()
        {
        }

        public IncorrectFormOfExpressionException(string message)
            : base(message)
        {
        }

        public IncorrectFormOfExpressionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected IncorrectFormOfExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
