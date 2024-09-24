using System;

namespace Filmkeeper.Exceptions
{
    public class InvalidArguementException : Exception
    {

        public InvalidArguementException() : base() { }

        public InvalidArguementException(string message) : base(message) { }

        public InvalidArguementException(string message, Exception innerException) : base(message, innerException) { }

    }
}

