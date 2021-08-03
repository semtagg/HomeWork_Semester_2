using System;
using System.Runtime.Serialization;

namespace HW_5_Task_2
{
    /// <summary>
    /// Exception which used if the graph is unconnected.
    /// </summary>
    [Serializable]
    public class GraphIsNotConnectedException : Exception
    {
        public GraphIsNotConnectedException()
        {
        }

        public GraphIsNotConnectedException(string message)
            : base(message)
        {
        }

        public GraphIsNotConnectedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected GraphIsNotConnectedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
