using System;

namespace ToWatIoc.Container.ContainerEntry
{
    /// <summary>
    /// Represents a given entry in the IoC container.
    /// </summary>
    public interface IContainerEntry
    {
        /// <summary>
        /// Resolves the current entry in the container
        /// </summary>
        /// <param name="dataType">The type to return</typeparam>
        /// <returns>A resolved instance of the specified type</returns>
        object Resolve(IocContainer container);
    }
}
