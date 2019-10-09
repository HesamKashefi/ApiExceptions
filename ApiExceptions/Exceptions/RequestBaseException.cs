using System;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Represents an exception regarding the http request
    /// Indicates a 500 response by default
    /// </summary>
    public abstract class RequestBaseException : Exception
    {
        public short HttpStatusCode { get; protected set; } = (short)System.Net.HttpStatusCode.InternalServerError;

        protected RequestBaseException(string message) : base(message)
        {
        }
    }
}
