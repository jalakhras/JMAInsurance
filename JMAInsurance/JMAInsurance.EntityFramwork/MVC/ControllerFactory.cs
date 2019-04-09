using JMAInsurance.Framework.Extensions;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace JMAInsurance.EntityFramwork.MVC
{
    public class ControllerFactory : DefaultControllerFactory
    {
        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            return base.GetControllerType(requestContext, controllerName) ?? typeof(NotFoundController);
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller = base.CreateController(requestContext, controllerName);

            if (controller.Is<Controller>())
            {
                controller.As<Controller>().ActionInvoker = new ActionInvoker();
            }

            return controller;
        }
    }
}
