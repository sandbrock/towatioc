using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToWatIoc.Container;
using ToWatIoc.Mvc.Controllers;

namespace ToWatIoc.Mvc.App_Start
{
    public static class ContainerConfig
    {
        public static IocContainer InitContainer()
        {
            var container = new IocContainer();

            container.Register<AboutController>();
            container.Register<HomeController>();

            return container;
        }
    }
}