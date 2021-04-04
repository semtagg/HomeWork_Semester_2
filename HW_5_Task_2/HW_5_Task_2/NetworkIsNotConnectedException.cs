using System;
using System.Runtime.Serialization;

namespace HW_5_Task_2
{
    [Serializable]
    public class NetworkIsNotConnectedException : Exception
    {
        public NetworkIsNotConnectedException()
        {
        }

        public NetworkIsNotConnectedException(string message)
            : base(message)
        {
        }

        public NetworkIsNotConnectedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NetworkIsNotConnectedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
