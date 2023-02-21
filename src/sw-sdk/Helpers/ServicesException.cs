using System;
using System.Runtime.Serialization;

namespace SW.Helpers
{
    [Serializable]
    internal class ServicesException : Exception
    {
        internal ServicesException()
        {
        }

        internal ServicesException(string message) : base(message)
        {
        }

        internal ServicesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServicesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}