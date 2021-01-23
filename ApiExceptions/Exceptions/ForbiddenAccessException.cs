using System;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Forbidden Access Exception
    /// Indicates a 403 response
    /// </summary>
    public class ForbiddenAccessException : ApiRequestException
    {
        public ForbiddenAccessException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Forbidden;
        }

        public ForbiddenAccessException(string message, Exception inner) : base(message, inner)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Forbidden;
        }
    }
}
