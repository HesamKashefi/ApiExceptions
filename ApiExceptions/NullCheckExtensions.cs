using ApiExceptions.Exceptions;

namespace ApiExceptions
{
    public static class NullCheckExtensions
    {
        /// <summary>
        /// Throws not found exception if the specified entity is null
        /// </summary>
        /// <typeparam name="T">The actual entity reference type</typeparam>
        /// <typeparam name="TKey">Id of the entity type</typeparam>
        /// <param name="entity">The actual entity reference</param>
        /// <param name="id">Id of the entity </param>
        /// <param name="message">An optional message for the exception</param>
        public static void ThrowEntityNotFoundIfNull<T, TKey>(this T entity,
            TKey id,
            string message = null)
            where T : class
        {
            if (entity is null)
            {
                throw new EntityNotFoundException(id, message ?? $"{typeof(T).Name} was not found.");
            }
        }
    }
}
