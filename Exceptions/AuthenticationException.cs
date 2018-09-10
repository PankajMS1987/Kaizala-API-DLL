using System;

namespace Microsoft.Kaizala.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base()
        {

        }
        public AuthenticationException(string message) : this(message, null)
        {

        }
        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public AuthenticationException(string errorCode, string message, Exception innerException=null) : this(message, innerException)
        {
            this.ErrorCode = errorCode;
        }

        private string ErrorCode;
    }
}
