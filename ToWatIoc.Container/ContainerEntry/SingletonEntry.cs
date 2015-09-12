using System;

namespace ToWatIoc.Container.ContainerEntry
{
    /// <summary>
    /// Represents a singleton entry in the container
    /// </summary>
    class SingletonEntry : IContainerEntry
    {
        public SingletonEntry(Type dataType)
        {
            _dataType = dataType;
        }

        public object Resolve(IocContainer container)
        {
            if (_instance == null)
            {
                _instance = IocObjectFactory.CreateObject(_dataType, container);
            }

            return _instance;
        }

        private Type _dataType;

        private object _instance = null;
    }
}
