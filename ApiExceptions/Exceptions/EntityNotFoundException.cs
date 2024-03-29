﻿using System;

namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Entity Not Found Exception
    /// Indicates a <see cref="System.Net.HttpStatusCode.NotFound"/> response
    /// </summary>
    public class EntityNotFoundException : ApiRequestException
    {
        public EntityNotFoundException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.NotFound;
        }

        public EntityNotFoundException(string message, Exception inner) : base(message, inner)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.NotFound;
        }

        public EntityNotFoundException(object key) : this(key, $"Entity with key = {key} was not found.")
        {
        }

        public EntityNotFoundException(object key, string message) : base($"Using key = '{key}' , " + message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.NotFound;
        }
    }
}
