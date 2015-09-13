using System.Threading.Tasks;
using ToWatIoc.Container.ContainerEntry;
using ToWatIoc.Container.Tests.TestClasses;
using ToWatIoc.Container.Tests.TestInterfaces;
using Xunit;

namespace ToWatIoc.Container.Tests
{
    public class IocContainerTests
    {

        [Fact]
        // Requires multiple cores/processors. Need load testing for true test.
        public void TestMultiThreading() 
        {
            var container = new IocContainer();
            var tasks = new Task[20];
            int taskIdx = 0;

            while (taskIdx < 20)
            {
                tasks[taskIdx++] = Task.Run(() =>
                {
                    container.Register<ConnectionName>();
                });

                tasks[taskIdx++] = Task.Run(() =>
                {
                    container.Register<ConnectionServer>();
                });
            }

            Task.WaitAll(tasks);
        }

        [Fact]
        public void TestRegisterSingletonClass()
        {
            var container = new IocContainer();
            container.Register(typeof(ConnectionName), LifestyleType.Singleton);

            ConnectionName connectionName = (ConnectionName)container.Resolve(typeof(ConnectionName));
            Assert.NotNull(connectionName);

            ConnectionName connectionName2 = (ConnectionName)container.Resolve(typeof(ConnectionName));
            Assert.NotNull(connectionName);
            Assert.Equal(connectionName, connectionName2);
        }

        [Fact]
        public void TestRegisterSingletonClassGeneric()
        {
            var container = new IocContainer();
            container.Register<ConnectionName>(LifestyleType.Singleton);

            ConnectionName connectionName = container.Resolve<ConnectionName>();
            Assert.NotNull(connectionName);

            ConnectionName connectionName2 = container.Resolve<ConnectionName>();
            Assert.NotNull(connectionName);
            Assert.Equal(connectionName, connectionName2);
        }

        [Fact]
        public void TestRegisterTransientClass()
        {
            var container = new IocContainer();
            container.Register(typeof(ConnectionName));

            ConnectionName connectionName = (ConnectionName)container.Resolve(typeof(ConnectionName));
            Assert.NotNull(connectionName);

            ConnectionName connectionName2 = (ConnectionName)container.Resolve(typeof(ConnectionName));
            Assert.NotNull(connectionName);
            Assert.NotEqual(connectionName, connectionName2);
        }

        [Fact]
        public void TestRegisterTransientClassGeneric()
        {
            var container = new IocContainer();
            container.Register<ConnectionName>();

            ConnectionName connectionName = container.Resolve<ConnectionName>();
            Assert.NotNull(connectionName);

            ConnectionName connectionName2 = container.Resolve<ConnectionName>();
            Assert.NotNull(connectionName);
            Assert.NotEqual(connectionName, connectionName2);
        }

        [Fact]
        public void TestRegisterSingletonInterface()
        {
            var container = new IocContainer();
            container.Register(typeof(ConnectionName));
            container.Register(typeof(IConnection), typeof(SqlConnection), LifestyleType.Singleton);

            IConnection connection = (IConnection)container.Resolve(typeof(IConnection));
            Assert.NotNull(connection);

            IConnection connection2 = (IConnection)container.Resolve(typeof(IConnection));
            Assert.NotNull(connection);
            Assert.Equal(connection, connection2);
        }

        [Fact]
        public void TestRegisterSingletonInterfaceGeneric()
        {
            var container = new IocContainer();
            container.Register<ConnectionName>();
            container.Register<IConnection, SqlConnection>(LifestyleType.Singleton);

            IConnection connection = container.Resolve<IConnection>();
            Assert.NotNull(connection);

            IConnection connection2 = container.Resolve<IConnection>();
            Assert.NotNull(connection);
            Assert.Equal(connection, connection2);
        }

        [Fact]
        public void TestRegisterTransientInterface()
        {
            var container = new IocContainer();
            container.Register(typeof(ConnectionName));
            container.Register(typeof(IConnection), typeof(SqlConnection));

            IConnection connection = (IConnection)container.Resolve(typeof(IConnection));
            Assert.NotNull(connection);

            IConnection connection2 = (IConnection)container.Resolve(typeof(IConnection));
            Assert.NotNull(connection);
            Assert.NotEqual(connection, connection2);
        }

        [Fact]
        public void TestRegisterTransientInterfaceGeneric()
        {
            var container = new IocContainer();
            container.Register<ConnectionName>();
            container.Register<IConnection, SqlConnection>();

            IConnection connection = container.Resolve<IConnection>();
            Assert.NotNull(connection);

            IConnection connection2 = container.Resolve<IConnection>();
            Assert.NotNull(connection);
            Assert.NotEqual(connection, connection2);
        }

    }
}
