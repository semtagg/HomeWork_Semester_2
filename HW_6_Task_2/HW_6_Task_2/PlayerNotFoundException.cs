using System;
using System.Runtime.Serialization;

namespace HW_6_Task_2
{
    /// <summary>
    /// The exception is thrown if the player is not found on the map.
    /// </summary>
    [Serializable]
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException()
        {
        }

        public PlayerNotFoundException(string message)
            : base(message)
        {
        }

        public PlayerNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected PlayerNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
