﻿namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Entity Not Found Exception
    /// Indicates a 404 response
    /// </summary>
    public class EntityNotFoundException : RequestBaseException
    {
        public EntityNotFoundException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.NotFound;
        }

        public EntityNotFoundException(object key) : this(key, $"Entity with key = {key} was not found.")
        {
        }

        public EntityNotFoundException(object key, string message) : base($"Using Id = '{key}' , " + message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.NotFound;
        }
    }
}