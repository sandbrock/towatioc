using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToWatIoc.Container.Tests.TestInterfaces;

namespace ToWatIoc.Container.Tests.TestClasses
{
    class SqlConnection : IConnection
    {
        public SqlConnection(ConnectionName connectionName)
        {
            if (connectionName == null)
            {
                throw new ArgumentException("connectionName must have a value");
            }
        }


        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
