using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_Task_1
{
    [Serializable]
    class CorrectExpressionException : Exception
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
