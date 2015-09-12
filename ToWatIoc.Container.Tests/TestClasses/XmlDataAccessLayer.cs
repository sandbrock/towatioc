using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToWatIoc.Container.Tests.TestInterfaces;

namespace ToWatIoc.Container.Tests.TestClasses
{
    class XmlDataAccessLayer : IDataAccessLayer
    {
        public XmlDataAccessLayer(IConnection connection)
        {
            if (!(connection is XmlConnection))
            {
                throw new ArgumentException("Expected XmlConnection fro the XmlDataAccessLayer");
            }
        }


        public object[] GetData()
        {
            throw new NotImplementedException();
        }
    }
}
