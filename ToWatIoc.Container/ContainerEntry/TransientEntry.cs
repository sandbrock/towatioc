using System;

namespace ToWatIoc.Container.ContainerEntry
{
    /// <summary>
    /// Represents a transient entry in the container
    /// </summary>
    class TransientEntry : IContainerEntry
    {
        public TransientEntry(Type dataType)
        {
            _dataType = dataType;
        }

        public object Resolve(IocContainer container)
        {
            return IocObjectFactory.CreateObject(_dataType, container);
        }

        private Type _dataType;
    }
}
