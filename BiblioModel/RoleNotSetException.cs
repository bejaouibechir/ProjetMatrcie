using System;
using System.Runtime.Serialization;

namespace BiblioModel
{
    [Serializable]
    internal class RoleNotSetException : Exception
    {
        public RoleNotSetException()
        {
        }

        public RoleNotSetException(string message) : base(message)
        {
        }

        public RoleNotSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoleNotSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}