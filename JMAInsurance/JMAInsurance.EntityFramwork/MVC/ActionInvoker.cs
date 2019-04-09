using JMAInsurance.Framework.Extensions;
using System.Web.Mvc;

namespace JMAInsurance.EntityFramwork.MVC
{
    public class ActionInvoker : ControllerActionInvoker
    {
        protected override ActionDescriptor FindAction(ControllerContext controllerContext, ControllerDescriptor controllerDescriptor, string actionName)
        {
            var descriptor = base.FindAction(controllerContext, controllerDescriptor, actionName);

            if (descriptor == null || controllerContext.Controller.Is<NotFoundController>())
            {
                return new NotFoundActionDescriptor();
            }

            return descriptor;
        }
    }
}
