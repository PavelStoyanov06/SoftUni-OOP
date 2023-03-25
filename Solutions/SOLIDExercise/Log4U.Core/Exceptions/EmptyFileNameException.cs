using System;
using System.Runtime.Serialization;

namespace Log4U.Core.IO
{
    internal class EmptyFileNameException : Exception
    {
        private const string DefaultMessage = "File name cannot be null or whitesspace";

        public EmptyFileNameException()
            : base(DefaultMessage)
        {
        }

        public EmptyFileNameException(string message) 
            : base(message)
        {
                
        }

        public EmptyFileNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyFileNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}