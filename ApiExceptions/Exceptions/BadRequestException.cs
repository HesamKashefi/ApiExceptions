using System;
using System.Collections.Generic;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Bad Request Exception
    /// Indicates a <see cref="System.Net.HttpStatusCode.BadRequest"/> response
    /// </summary>
    public class BadRequestException : ApiRequestException
    {
        public BadRequestException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.BadRequest;
        }

        public BadRequestException(string message, Exception inner) : base(message, inner)
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
            if (Errors.ContainsKey(key))
            {
                var ls = new List<string>(Errors[key]) { error };
                Errors[key] = ls.ToArray();
            }
            else
            {
                Errors[key] = new[] { error };
            }
        }

        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
    }
}
