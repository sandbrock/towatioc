using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToWatIoc.Container.ContainerEntry
{
    /// <summary>
    /// A list of object lifestyles
    /// </summary>
    public enum LifestyleType
    {
        Transient,
        Singleton
    };

    /// <summary>
    /// Creates an entry object depending on the lifestyle
    /// </summary>
    public static class EntryFactory
    {
        public static IContainerEntry GetEntry(LifestyleType lifestyleType, Type dataType)
        {
            IContainerEntry result = null;

            switch(lifestyleType)
            {
                case LifestyleType.Transient:
                    result = new TransientEntry(dataType);
                    break;

                case LifestyleType.Singleton:
                    result = new SingletonEntry(dataType);
                    break;
            }

            return result;
        }

    }
}
