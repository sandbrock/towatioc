using System;
using System.Collections.Generic;
using System.Reflection;

namespace ToWatIoc.Container
{
    /// <summary>
    /// Used to create instances of objects
    /// </summary>
    static class IocObjectFactory
    {
        public static object CreateObject(Type objectType, IocContainer container)
        {
            // The type must be a class type
            if (!objectType.IsClass)
            {
                throw new ArgumentException(string.Format("Expected type of class, but received type of {0}", objectType.ToString()));
            }

            object result = null;
            ConstructorInfo[] constructors = objectType.GetConstructors();
            if (constructors.Length > 0)
            {
                ConstructorInfo constructorInfo = constructors[0]; // Assume default constructor
                ParameterInfo[] paramInfos = constructorInfo.GetParameters();
                var constructorParams = new List<object>();
                foreach(ParameterInfo paramInfo in paramInfos)
                {
                    constructorParams.Add(container.Resolve(paramInfo.ParameterType));
                }
                result = constructorInfo.Invoke(constructorParams.ToArray());
            }

            return result;
        }
    }
}
