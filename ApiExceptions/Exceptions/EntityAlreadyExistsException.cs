namespace ApiExceptions.Exceptions
{
    /// <summary>
    /// Entity Already Exists Exception
    /// Indicates a 409 response
    /// </summary>
    public class EntityAlreadyExistsException : RequestBaseException
    {
        public EntityAlreadyExistsException(string message) : base(message)
        {
            HttpStatusCode = (short)System.Net.HttpStatusCode.Conflict;
        }
    }
}
