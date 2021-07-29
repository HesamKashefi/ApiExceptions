using System;
using System.Net.Http;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Represents exception from the api requests
    /// Can be thrown when calling external APIs
    /// </summary>
    public class ApiRequestException : HttpRequestException
    {
        public short HttpStatusCode { get; protected set; } = (short)System.Net.HttpStatusCode.InternalServerError;

        public ApiRequestException() : base("API Request Failed")
        {

        }

        public ApiRequestException(short httpStatusCode) : this()
        {
            HttpStatusCode = httpStatusCode;
        }

        public ApiRequestException(string message) : base(message)
        {

        }

        public ApiRequestException(string message, short httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public ApiRequestException(string message, Exception inner) : base(message, inner)
        {

        }

        public ApiRequestException(string message, Exception inner, short httpStatusCode) : base(message, inner)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
