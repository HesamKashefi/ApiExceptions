namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// UnAuthorized Access exception
    /// Indicates a 401 response
    /// </summary>
    public class UnAuthorizedAccessException : ApiRequestException
    {
        public UnAuthorizedAccessException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
