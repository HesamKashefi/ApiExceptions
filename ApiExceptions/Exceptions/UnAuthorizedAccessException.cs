using System;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// UnAuthorized Access exception
    /// Indicates a <see cref="System.Net.HttpStatusCode.Unauthorized"/> response
    /// </summary>
    public class UnAuthorizedAccessException : ApiRequestException
    {
        public UnAuthorizedAccessException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Unauthorized;
        }

        public UnAuthorizedAccessException(string message, Exception inner) : base(message, inner)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
