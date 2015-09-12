using System;
using System.Collections.Concurrent;
using ToWatIoc.Container.ContainerEntry;

namespace ToWatIoc.Container
{
    /// <summary>
    /// This is the actual container.
    /// It is this class that the developer will be interacting with.
    /// </summary>
    public class IocContainer
    {
        /// <summary>
        /// Registers a concrete class type in the container
        /// </summary>
        /// <typeparam name="classType">The class type to register</typeparam>
        /// <typeparam name="lifestyle">The object lifestyle to use</typeparam>
        public void Register(Type classType, LifestyleType lifestyleType = LifestyleType.Transient)
        {
            RegisterClassType(classType, lifestyleType);
        }

        /// <summary>
        /// Registers a concrete class type in the container
        /// </summary>
        /// <typeparam name="T">The class type to register</typeparam>
        public void Register<T>(LifestyleType lifestyleType = LifestyleType.Transient)
        {
            Register(typeof(T), lifestyleType);
        }

        /// <summary>
        /// Registers an interface and associates it with a concrete class
        /// </summary>
        /// <typeparam name="interfaceType">The interface type</typeparam>
        /// <typeparam name="classType">The concrete class type</typeparam>
        public void Register(Type interfaceType, Type classType, LifestyleType lifestyleType = LifestyleType.Transient)
        {
            RegisterInterfaceType(interfaceType, classType, lifestyleType);
        }

        /// <summary>
        /// Registers an interface and associates it with a concrete class
        /// </summary>
        /// <typeparam name="T">The interface type</typeparam>
        /// <typeparam name="T2">The concrete class type</typeparam>
        public void Register<T, T2>(LifestyleType lifestyleType = LifestyleType.Transient)
        {
            Register(typeof(T), typeof(T2), lifestyleType);
        }

        /// <summary>
        /// Resolves a type to an instance
        /// </summary>
        /// <typeparam name="dataType">The type to resolve</typeparam>
        /// <returns>The instance the type was resolved to</returns>
        public object Resolve(Type lookupType)
        {
            if (_entries.ContainsKey(lookupType))
            {
                return _entries[lookupType].Resolve(this);
            }

            throw new ArgumentOutOfRangeException(string.Format("The specified type {0} is not registered in the container", lookupType.ToString()));
        }

        /// <summary>
        /// Resolves a type to an instance
        /// </summary>
        /// <typeparam name="T">The type to resolve</typeparam>
        /// <returns>The instance the type was resolved to</returns>
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        /// <summary>
        ///  Internal thread-safe dictionary of entries
        /// </summary>
        private ConcurrentDictionary<Type, IContainerEntry> _entries = new ConcurrentDictionary<Type, IContainerEntry>();

        /// <summary>
        /// Registers a concrete class type in the container
        /// </summary>
        /// <typeparam name="classType">The type to register</typeparam>
        /// <param name="entry">The container entry to be added</param>
        private void RegisterClassType(Type classType, LifestyleType lifestyleType)
        {
            // Abort if the lookupType is not a class
            if (!classType.IsClass)
            {
                throw new ArgumentException(string.Format("Expected lookup type of class, but received type of {0}", classType.ToString()));
            }

            if (!_entries.ContainsKey(classType))
            {
                _entries.TryAdd(classType, EntryFactory.GetEntry(lifestyleType, classType));
            }
        }

        /// <summary>
        /// Registers an interface type in the container, and associates
        /// it with a conrete class type.
        /// </summary>
        /// <typeparam name="interfaceType">The interface type</typeparam>
        /// <typeparam name="classType">The concrete class type</typeparam>
        /// <param name="entry">The container entry to add</param>
        private void RegisterInterfaceType(Type interfaceType, Type classType, LifestyleType lifestyleType)
        {
            // Abort if the lookupType is not an interface
            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException(string.Format("Expected lookup type of interface, but received type of {0}", interfaceType.ToString()));
            }

            // Abort if the entryType is not a class
            if (!classType.IsClass)
            {
                throw new ArgumentException(string.Format("Expected entry type of class, but received type of {0}", classType.ToString()));
            }

            if (!_entries.ContainsKey(interfaceType))
            {
                _entries.TryAdd(interfaceType, EntryFactory.GetEntry(lifestyleType, classType));
            }
        }
    }
}
