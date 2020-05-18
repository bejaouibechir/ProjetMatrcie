using System;
using System.Runtime.Serialization;

namespace BiblioModel
{
    [Serializable]
    internal class ConfirmPasswordException : Exception
    {
        public ConfirmPasswordException()
        {
        }

        public ConfirmPasswordException(string message) : base(message)
        {
        }

        public ConfirmPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConfirmPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}