using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToWatIoc.Container.Tests.TestInterfaces
{
    interface IConnection
    {
        void Connect();

        void Disconnect();
    }
}
