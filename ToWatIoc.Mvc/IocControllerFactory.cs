using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ToWatIoc.Container;
using ToWatIoc.Mvc.App_Start;

namespace ToWatIoc.Mvc
{
    public class IocControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //return base.GetControllerInstance(requestContext, controllerType);
            return (IController)_container.Resolve(controllerType);
        }

        private IocContainer _container = ContainerConfig.InitContainer();
    }
}