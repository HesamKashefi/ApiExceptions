using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Bad Request Exception
    /// Indicates a 400 response
    /// </summary>
    public class BadRequestException : ApiRequestException
    {
        public BadRequestException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.BadRequest;
        }

        /// <summary>
        /// Adds an error to the model state dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="error"></param>
        public void AddModelError(string key, string error)
        {
            ModelState.AddModelError(key, error);
        }

        public ModelStateDictionary ModelState { get; } = new ModelStateDictionary();
    }
}
