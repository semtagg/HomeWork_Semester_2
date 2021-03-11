using System;
using System.Runtime.Serialization;

namespace HW_4_Task_2
{
    [Serializable]
    class AddElementError : Exception
    {
        public AddElementError() 
        {
        }

        public AddElementError(string message) 
            : base (message) 
        {
        }

        public AddElementError(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected AddElementError(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }
    }
}
