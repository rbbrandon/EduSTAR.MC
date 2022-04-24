using System;
using System.Runtime.Serialization;

namespace EduSTAR.MC.API.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base() {

        }

        public InvalidCredentialsException(string message) : base(message) {

        }

        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException) {

        }

        public InvalidCredentialsException(SerializationInfo info, StreamingContext context) : base(info, context) {

        }
    }
}
