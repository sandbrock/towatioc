using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToWatIoc.Container.Tests.TestInterfaces;

namespace ToWatIoc.Container.Tests.TestClasses
{
    class SqlDataAccessLayer : IDataAccessLayer
    {
        public SqlDataAccessLayer(IConnection connection)
        {
            if (!(connection is SqlConnection))
            {
                throw new ArgumentException("Must assign SqlConnection to SqlDataAccessLayer");
            }
        }

        public object[] GetData()
        {
            throw new NotImplementedException();
        }
    }
}
