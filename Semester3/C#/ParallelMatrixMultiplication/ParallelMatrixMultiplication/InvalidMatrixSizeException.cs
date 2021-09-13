using System;
using System.Runtime.Serialization;

namespace ParallelMatrixMultiplication
{
    /// <summary>
    /// An exception is thrown if the dimensions of the matrix are not comparable.
    /// </summary>
    [Serializable]
    public class InvalidMatrixSizeException : Exception
    {
        public InvalidMatrixSizeException()
        {
        }

        public InvalidMatrixSizeException(string message)
            : base(message)
        {
        }

        public InvalidMatrixSizeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected InvalidMatrixSizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
