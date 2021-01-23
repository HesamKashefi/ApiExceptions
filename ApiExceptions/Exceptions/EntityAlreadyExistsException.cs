using System;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Entity Already Exists Exception
    /// Indicates a 409 response
    /// </summary>
    public class EntityAlreadyExistsException : ApiRequestException
    {
        public EntityAlreadyExistsException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Conflict;
        }

        public EntityAlreadyExistsException(string message, Exception inner) : base(message, inner)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Conflict;
        }
    }
}
