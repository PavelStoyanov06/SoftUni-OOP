using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4U.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultMessage = "File extension cannot be null or whitespace";

        public EmptyFileExtensionException()
            : base(DefaultMessage)
        {
            
        }

        public EmptyFileExtensionException(string message)
            : base(message)
        {
            
        }
    }
}
