using ToWatIoc.Container.ContainerEntry;
using ToWatIoc.Container.Tests.TestClasses;
using ToWatIoc.Container.Tests.TestInterfaces;
using Xunit;

namespace ToWatIoc.Container.Tests
{
    public class EntryFactoryTests
    {
        [Fact]
        public void TestGetSingletonEntry()
        {
            IContainerEntry entry = EntryFactory.GetEntry(LifestyleType.Singleton, typeof(ConnectionName));
            Assert.NotNull(entry);
        }

        [Fact]
        public void TestGetTransientEntry()
        {
            IContainerEntry entry = EntryFactory.GetEntry(LifestyleType.Transient, typeof(ConnectionName));
            Assert.NotNull(entry);
        }
    }
}
