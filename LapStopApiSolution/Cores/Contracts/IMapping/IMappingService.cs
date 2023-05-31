namespace Contracts.IMapping
{
    public interface IMappingService
    {
        /// <summary>
        /// Execute a mapping from the Source object to a [NEW] Destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use, regardless of the runtime type</typeparam>
        /// <typeparam name="TDestination">Destination type to create</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <returns>Mapped Destination object</returns>
        public TDestination Map<TSource, TDestination>(TSource source);

        /// <summary>
        /// Execute a mapping from the Source object to the [EXISTING] Destination object.
        /// </summary>
        /// <typeparam name="TSource">Source type to use</typeparam>
        /// <typeparam name="TDestination">Destination type</typeparam>
        /// <param name="source">Source object to map from</param>
        /// <param name="destination">Destination object to map into</param>
        /// <returns>The mapped Destination object, [SAME] instance as the <paramref name="destination"/> object</returns>
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
