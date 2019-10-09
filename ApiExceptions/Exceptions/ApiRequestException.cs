using System.Net.Http;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Represents exception from the api requests
    /// Can be thrown when calling external APIs
    /// </summary>
    public class ApiRequestException : HttpRequestException
    {
        public ApiRequestException(string message) : base(message)
        {
            
        }
    }
}
