using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JMAInsurance.EntityFramwork.MVC
{
    internal class NotFoundActionDescriptor : ActionDescriptor
    {
        public override string ActionName => String.Empty;

        public override ControllerDescriptor ControllerDescriptor =>
            new ReflectedControllerDescriptor(typeof(NotFoundController));

        public override object Execute(ControllerContext controllerContext, IDictionary<string, object> parameters) =>
            new NotFoundViewResult();

        public override ParameterDescriptor[] GetParameters() => new ParameterDescriptor[] { };
    }
}